using System;
using System.ComponentModel.DataAnnotations;

namespace TimetableApi.Models
{
    public class Timetable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GradeId { get; set; }
        public virtual Grade Grade { set; get; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public virtual Subject Subject { set; get; }

        [Required]
        public DateTime StartAt { get; set; }

        [Required]
        public DateTime EndsAt { get; set; }

        public int? LeaveId { get; set; }

        public virtual  Leave Leave { set; get; }
    }
}
