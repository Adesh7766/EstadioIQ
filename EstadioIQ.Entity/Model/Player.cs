using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.Model
{
    public class Player
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        public string Position { get; set; } // e.g., "Forward", "Midfielder"
        public string CurrentTeam { get; set; }

        public int TotalGoals { get; set; }
        public int TotalAssists { get; set; }
        public int MatchesPlayed { get; set; }

        public double AverageRating { get; set; } // e.g., from SofaScore
        public double PassAccuracy { get; set; }

        public bool IsActive { get; set; }

        public string PhotoUrl { get; set; } 

        public List<MatchPerformance> Performances { get; set; } // Link to match data
    }
}
