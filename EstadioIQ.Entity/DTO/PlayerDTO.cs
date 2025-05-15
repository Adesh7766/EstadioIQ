using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.DTO
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string CurrentTeam { get; set; }

        public int TotalGoals { get; set; }
        public int TotalAssists { get; set; }
        public int MatchesPlayed { get; set; }
        public double AverageRating { get; set; }
        public double PassAccuracy { get; set; }
        public string PhotoUrl { get; set; }
    }

}
