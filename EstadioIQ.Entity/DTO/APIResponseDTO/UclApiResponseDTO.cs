using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.DTO.APIResponseDTO
{
    public class UclApiResponseDTO
    {
        public Filters Filters { get; set; }
        public ResultSet ResultSet { get; set; }
        public CompetitionDto Competition { get; set; }
        public List<MatchFromApi> Matches { get; set; }

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

    public class CompetitionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Emblem { get; set; }
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

        public TeamDto HomeTeam { get; set; }
        public TeamDto AwayTeam { get; set; }
        public Score Score { get; set; }

        public Odds Odds { get; set; }
        public List<RefereeDto> Referees { get; set; }
    }

    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string Crest { get; set; }
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

    public class AreaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
    }

    public class SeasonDto
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public string Winner { get; set; }  // Can be null
    }

    public class Odds
    {
        public string Msg { get; set; }
    }

    public class RefereeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Nationality { get; set; }
    }
}
