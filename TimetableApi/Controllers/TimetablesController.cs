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
    public class TimetablesController : ControllerBase
    {
        private readonly ITimetableRepo _repository;
        private readonly IMapper _mapper;

        public TimetablesController(ITimetableRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("{path}/{id}", Name = "GetTimetables")]
        public ActionResult<IEnumerable<Timetable>> GetTimetables(string path,int id)
        {
            if (String.Equals(path, "students"))
            {
                var student = _repository.GetStudentById(id);
                if (student == null)
                    return NotFound();
                
                return Ok(_mapper.Map<StudentTimetableReadDto>(student));
            }
            if (String.Equals(path, "teachers"))
            {
                var teacher = _repository.GetTeacherById(id);

                if (teacher == null)
                    return NotFound();

                return Ok(_mapper.Map<TeacherTimetableReadDto>(teacher));
            }

            return NotFound();
           
        }
    }
}
