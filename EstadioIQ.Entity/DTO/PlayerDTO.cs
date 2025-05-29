using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.DTO
{
    public class PlayerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Nationality { get; set; }
        public string Position { get; set; }

        public string CurrentTeam { get; set; }

        [Required]
        public int TotalGoals { get; set; }

        [Required]
        public int TotalAssists { get; set; }

        [Required]
        public int MatchesPlayed { get; set; }

        [Required]
        public double AverageRating { get; set; }
        public double PassAccuracy { get; set; }
        public string PhotoUrl { get; set; }
        public double TotalScore { get; set; }
        public int TotalGA { get; set; }
    }

    public class PlayerFormDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalGoals { get; set; }

        public int TotalAssists { get; set; }

        public double AverageRating { get; set; }

        public int MinutesPlayed { get; set; }

        public bool IsStarter { get; set; }

        public DateTime MatchDate { get; set; }
    }

}
