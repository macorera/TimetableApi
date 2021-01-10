using System;
using System.ComponentModel.DataAnnotations;

namespace TimetableApi.Models
{
    public class Leave
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }
    }
}
