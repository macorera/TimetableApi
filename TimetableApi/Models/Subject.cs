using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimetableApi.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
