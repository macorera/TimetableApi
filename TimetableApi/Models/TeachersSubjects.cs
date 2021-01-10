using System;
using System.ComponentModel.DataAnnotations;

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
        public DateTime CreatedAt { get; set; }
    }
}
