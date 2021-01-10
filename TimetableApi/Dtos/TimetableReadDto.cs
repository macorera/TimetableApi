using System;

namespace TimetableApi.Dtos
{
    public class TimetableReadDto
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndsAt { get; set; }
        public virtual GradeReadDto Grade { set; get; }
        public virtual SubjectReadDto    Subject { set; get; }
    }
}
