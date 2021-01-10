using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimetableApi.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
