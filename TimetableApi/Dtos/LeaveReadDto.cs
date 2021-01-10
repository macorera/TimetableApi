using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
