using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
