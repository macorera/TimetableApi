using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Models;

namespace TimetableApi.Dtos
{
    public class TeacherTimetableReadDto
    {
        public string Name { set; get; }
        public List<TimetableReadDto> Timetables { set; get; }
    }
}
