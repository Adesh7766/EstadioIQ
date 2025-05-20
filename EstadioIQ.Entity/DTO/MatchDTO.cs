using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.DTO
{
    public class MatchDto
    {
        public int Id { get; set; }

        [Required]
        public string HomeTeam { get; set; }

        [Required]
        public string AwayTeam { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public string Competition { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public string Venue { get; set; }

        public List<MatchPerformanceDto> PlayerPerformances { get; set; }
    }

}
