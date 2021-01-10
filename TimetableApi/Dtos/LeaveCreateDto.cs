using System;

namespace TimetableApi.Dtos
{
    public class LeaveCreateDto
    {
        public int TeacherId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
