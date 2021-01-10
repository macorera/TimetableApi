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

namespace TimetableApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ITimetableRepo _repository;
        private readonly IMapper _mapper;

        public StudentsController(ITimetableRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var students = _repository.GetAllStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student != null)
                return Ok(_mapper.Map<StudentReadDto>(student));
            return NotFound();
        }
    }
}
