using System.ComponentModel.DataAnnotations;

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
    }
}
