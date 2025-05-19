using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.DTO
{
    public class MatchPerformanceDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }

        public int Goals { get; set; }
        public int Assists { get; set; }
        public int PassesCompleted { get; set; }
        public double Rating { get; set; }

        public bool IsActive { get; set; }
        public bool IsStarter { get; set; }
        public int MinutesPlayed { get; set; }
    }


}
