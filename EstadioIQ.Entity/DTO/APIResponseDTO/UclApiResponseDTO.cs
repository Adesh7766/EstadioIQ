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
        public Competition Competition { get; set; }
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

    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Emblem { get; set; }
    }

    public class MatchFromApi
    {
        public Area Area { get; set; }
        public Competition Competition { get; set; }  // Already declared class
        public Season Season { get; set; }

        public int Id { get; set; }
        public string UtcDate { get; set; }
        public string Status { get; set; }
        public int Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public string LastUpdated { get; set; }

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Score Score { get; set; }

        public Odds Odds { get; set; }
        public List<Referee> Referees { get; set; }
    }

    public class Team
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

    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
    }

    public class Season
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

    public class Referee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Nationality { get; set; }
    }
}
