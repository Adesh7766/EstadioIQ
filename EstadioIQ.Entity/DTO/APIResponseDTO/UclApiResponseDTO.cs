using EstadioIQ.Entity.Model;

namespace EstadioIQ.Entity.DTO.APIResponseDTO
{
    public class UclApiResponseDTO
    {
        public Filters Filters { get; set; }
        public ResultSet ResultSet { get; set; }
        public CompetitionDto Competition { get; set; }
        public List<MatchFromApi> Matches { get; set; }
        public List<Club> Teams { get; set; }

    }

    public class Filters
    {
        public string Season { get; set; }
    }

    public class ResultSet
    {
        public int Count { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Played { get; set; }
    }

    public class MatchFromApi
    {
        public AreaDto Area { get; set; }
        public CompetitionDto Competition { get; set; }  // Already declared class
        public SeasonDto Season { get; set; }

        public int Id { get; set; }
        public string UtcDate { get; set; }
        public string Status { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public string LastUpdated { get; set; }

        public ClubDto HomeTeam { get; set; }
        public ClubDto AwayTeam { get; set; }
        public Score Score { get; set; }
        public Odds Odds { get; set; }
        public List<RefreeDto> Referees { get; set; }
    }

    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public FullTime FullTime { get; set; }
        public HalfTime HalfTime { get; set; }
    }

    public class FullTime
    {
        public int Home { get; set; }
        public int Away { get; set; }
    }

    public class HalfTime
    {
        public int Home { get; set; }
        public int Away { get; set; }
    }       

    public class Odds
    {
        public string Msg { get; set; }
    }    
}
