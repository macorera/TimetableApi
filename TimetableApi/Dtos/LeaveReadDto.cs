using System;

namespace TimetableApi.Dtos
{
    public class LeaveReadDto
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
