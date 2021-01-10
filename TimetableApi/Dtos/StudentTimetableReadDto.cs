using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Models;

namespace TimetableApi.Dtos
{
    public class StudentTimetableReadDto
    {
        public string Name { set; get; }
        public int GradeId { set; get; }
        public List<Timetable> Timetables { set; get; }
    }
}
