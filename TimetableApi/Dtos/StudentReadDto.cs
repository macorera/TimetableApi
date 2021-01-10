using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Models;

namespace TimetableApi.Dtos
{
    public class StudentReadDto
    {
        public string Name { set; get; }

        public GradeReadDto Grade { set; get; }
    }
}
