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
        public Grade Grade { set; get; }
    }
}
