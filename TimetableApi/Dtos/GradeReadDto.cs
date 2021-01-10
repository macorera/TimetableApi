using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimetableApi.Dtos
{
    public class GradeReadDto
    {
        public string Title { get; set; }
        public List<SubjectReadDto> Subjects { get; set; }
        public List<StudentReadDto> Students { get; set; }
        public List<TimetableReadDto> Timetables { get; set; }

    }
}
