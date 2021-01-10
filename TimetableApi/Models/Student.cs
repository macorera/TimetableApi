using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimetableApi.Models
{
    public class Student
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public int GradeId { set; get; }
        public virtual Grade Grade { set; get; }

        //public virtual List<Timetable> Timetables { set; get; }
    }
}
