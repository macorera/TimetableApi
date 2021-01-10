using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimetableApi.Models
{
    public class Grade
    {
        [Key]
        public int Id { set; get; }
        
        [Required]
        public string Title { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }
    }
}
