using System;

namespace TimetableApi.Models
{
    public class GradesSubjects
    {
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        public Grade Grade { get; set; }
        public Subject Subject { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
