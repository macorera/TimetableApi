using System.Collections.Generic;

namespace TimetableApi.Dtos
{
    public class SubjectReadDto
    {
        public string Title { get; set; }
        public List<TeacherReadDto> Teachers { get; set; }
    }
}
