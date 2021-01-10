using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimetableApi.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name{ get; set; }
        public List<Subject> Subjects { get; set; }

        public List<Timetable> Timetables { get; set; }
    }
}
