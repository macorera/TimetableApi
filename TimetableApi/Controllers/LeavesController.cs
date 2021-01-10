using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimetableApi.Data;
using TimetableApi.Data.Context;
using TimetableApi.Dtos;
using TimetableApi.Models;

namespace TimetableApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ITimetableRepo _repository;
        private readonly IMapper _mapper;

        public LeavesController(ITimetableRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetLeaveById")]
        public ActionResult<LeaveReadDto> GetLeaveById(int id)
        {
            var leave = _repository.GetLeaveById(id);
            if (leave != null)
                return Ok(_mapper.Map<LeaveReadDto>(leave));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<LeaveReadDto> CreateLeave(LeaveCreateDto leaveCreateDto)
        {
            var leave= _mapper.Map<Leave>(leaveCreateDto);
            _repository.CreateLeave(leave);
            _repository.SaveChanges();

            var leaveReadDto = _mapper.Map<LeaveReadDto>(leave);

            return CreatedAtRoute(nameof(GetLeaveById), new { Id = leaveReadDto.Id }, leaveReadDto);
        }
    }
}
