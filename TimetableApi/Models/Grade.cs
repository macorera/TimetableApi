using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimetableApi.Models
{
    public class Grade
    {
        [Key]
        public int Id { set; get; }
        
        [Required]
        public string Title { get; set; }

        public virtual List<Subject> Subjects { get; set; }

        public virtual List<Student> Students { get; set; }

        public virtual List<Timetable> Timetables { get; set; }
    }
}
