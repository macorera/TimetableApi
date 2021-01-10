using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimetableApi.Data.Context;
using TimetableApi.Dtos;

namespace TimetableApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ITimetableRepo _repository;
        private readonly IMapper _mapper;

        public SubjectsController(ITimetableRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubjectReadDto>> GetAllSubjects()
        {
            var subjects = _repository.GetAllSubjects();
            return Ok(_mapper.Map<IEnumerable<SubjectReadDto>>(subjects));
        }

        [HttpGet("{id}", Name = "GetSubjectById")]
        public ActionResult<SubjectReadDto> GetSubjectById(int id)
        {
            var subject = _repository.GetSubjectById(id);
            if (subject != null)
                return Ok(_mapper.Map<SubjectReadDto>(subject));
            return NotFound();
        }
    }
}
