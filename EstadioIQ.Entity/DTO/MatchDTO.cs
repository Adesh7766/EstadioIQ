using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.DTO
{
    public class MatchDto
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public string Competition { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public string Venue { get; set; }

        public List<MatchPerformanceDto> PlayerPerformances { get; set; }
    }

}
