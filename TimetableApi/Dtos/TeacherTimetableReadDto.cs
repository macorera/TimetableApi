using System.Collections.Generic;

namespace TimetableApi.Dtos
{
    public class TeacherTimetableReadDto
    {
        public string Name { set; get; }
        public List<TimetableReadDto> Timetables { set; get; }
    }
}
