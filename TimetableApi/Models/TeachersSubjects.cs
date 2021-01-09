using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimetableApi.Models
{
    public class TeachersSubjects
    {
        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
