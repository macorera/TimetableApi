using System.Collections.Generic;
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
