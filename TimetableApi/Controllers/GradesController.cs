using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimetableApi.Data.Context;
using TimetableApi.Dtos;

namespace TimetableApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly ITimetableRepo _repository;
        private readonly IMapper _mapper;

        public GradesController(ITimetableRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GradeReadDto>> GetAllGrades() {
            var grades = _repository.GetAllGrades();
            return Ok(_mapper.Map<IEnumerable<GradeReadDto>>(grades));
        }

        [HttpGet("{id}", Name = "GetGradeById")]
        public ActionResult<GradeReadDto> GetGradeById(int id)
        {
            var grade = _repository.GetGradeById(id);
            if (grade != null)
                return Ok(_mapper.Map<GradeReadDto>(grade));
            return NotFound();
        }


    }
}
