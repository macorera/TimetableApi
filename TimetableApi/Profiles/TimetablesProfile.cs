using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Dtos;
using TimetableApi.Models;

namespace TimetableApi.Profiles
{
    public class TimetablesProfile : Profile
    {
        public TimetablesProfile()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<Grade, GradeReadDto>();
            CreateMap<Subject, SubjectReadDto>();
            CreateMap<Teacher, TeacherReadDto>();
            CreateMap<Student, StudentTimetableReadDto>();
            CreateMap<Teacher, TeacherTimetableReadDto>();
            CreateMap<Timetable, TimetableReadDto>();
            CreateMap<Leave, LeaveReadDto>();
            CreateMap<LeaveCreateDto, Leave>();
        }
    }
}
