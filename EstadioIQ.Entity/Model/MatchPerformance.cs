using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.Model
{
    public class MatchPerformance
    {
        [Key]

        public int Id { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int Goals { get; set; }
        public int Assists { get; set; }
        public int PassesCompleted { get; set; }
        public double Rating { get; set; } // Player performance rating

        public bool IsStarter { get; set; }
        public int MinutesPlayed { get; set; }
    }
}
