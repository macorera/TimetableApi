using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Models;

namespace TimetableApi.Dtos
{
    public class SubjectReadDto
    {
        public string Title { get; set; }
        public List<TeacherReadDto> Teachers { get; set; }
    }
}
