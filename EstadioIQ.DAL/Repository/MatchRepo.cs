using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace EstadioIQ.DAL.Repository
{
    public class MatchRepo : IMatchRepo
    {
        private readonly ApplicationDbContext _context;

        public MatchRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<MatchDto>> GetMatches(string? homeTeam,
                                                       string? awayTeam,
                                                       DateTime? matchDate,
                                                       string? competetion,
                                                       string? venue,
                                                       int page,
                                                       int size)
        {
            var query = _context.Matches.Where(x => x.IsActive == true);

            if (!string.IsNullOrEmpty(homeTeam))
                query = query.Where(x => x.HomeTeam.Contains(homeTeam));

            if (!string.IsNullOrEmpty(awayTeam))
                query = query.Where(x => x.AwayTeam.Contains(awayTeam));

            if (matchDate.HasValue)
                query = query.Where(x => x.MatchDate == matchDate);

            if (!string.IsNullOrEmpty(competetion))
                query = query.Where(x => x.Competition.Contains(competetion));

            if (!string.IsNullOrEmpty(venue))
                query = query.Where(x => x.Venue.Contains(venue));

            var totalCount = query.Count();

            var matches = query
                    .Skip((page - 1) * size)
                    .Take(size)
                    .Select(x => new MatchDto
                    {
                        Id = x.Id,
                        HomeTeam = x.HomeTeam,
                        AwayTeam = x.AwayTeam,
                        MatchDate = x.MatchDate,
                        Competition = x.Competition,
                        HomeScore = x.HomeScore,
                        AwayScore = x.AwayScore,
                        IsActive = x.IsActive,
                        Venue = x.Venue
                    }).ToList();

            return new ResponseData<List<MatchDto>>
            {
                SuccessStatus = true,
                Message = $"Page {page} of all matches.",
                Data = matches,
                TotalCount = totalCount
            };
        }

        public ResponseData<MatchDto> GetMatchById(int id)
        {
            var match = _context.Matches.Where(x => x.IsActive == true && x.Id == id).Select(x => new MatchDto
            {
                Id = x.Id,
                HomeTeam = x.HomeTeam,
                AwayTeam = x.AwayTeam,
                MatchDate = x.MatchDate,
                Competition = x.Competition,
                HomeScore = x.HomeScore,
                AwayScore = x.AwayScore,
                IsActive = x.IsActive,
                Venue = x.Venue
            }).FirstOrDefault();

            if (match == null)
            {
                return new ResponseData<MatchDto>
                {
                    SuccessStatus = false,
                    Message = "Match not found."
                };
            }

            return new ResponseData<MatchDto>
            {
                SuccessStatus = true,
                Message = "Match found successfully.",
                Data = match
            };
        }

        public ResponseData UpdateMatch(Match match)
        {
            var dbData = _context.Matches.Where(x => x.IsActive == true && x.Id == match.Id).FirstOrDefault();

            if (dbData != null)
            {

                dbData.HomeTeam = match.HomeTeam;
                dbData.AwayTeam = match.AwayTeam;
                dbData.MatchDate = match.MatchDate;
                dbData.Competition = match.Competition;
                dbData.HomeScore = match.HomeScore;
                dbData.AwayScore = match.AwayScore;
                dbData.IsActive = match.IsActive;
                dbData.Venue = match.Venue;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Match updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "Match not found."
            };
        }

        public ResponseData DeleteMatch(int id)
        {
            var match = _context.Matches.Where(x => x.IsActive == true).FirstOrDefault();

            if (match == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Match not found."
                };
            }

            match.IsActive = false;

            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Match deleted successfully.",
            };
        }

        public ResponseData AddMatch(Match match)
        {
            if (match.HomeTeam == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "HomeTeam is required."
                };
            }
            else if (match.AwayTeam == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "AwayTeam is required."
                };
            }
            else if (match.Competition == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Competition is required."
                };
            }
            else if (match.Venue == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Venue is required."
                };
            }

            _context.Matches.Add(match);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Match Added successfully."
            };
        }

        public ResponseData GetMatchSummary(int matchId)
        {

            try
            {
                var matchDetails = _context.MatchPerformances
                                .Where(mp => mp.IsActive && mp.MatchId == matchId)
                                .GroupBy(g => g.MatchId)
                                .Select(x => new
                                {
                                    TotalGoals = x.Sum(y => y.Goals),
                                    TotalAssists = x.Sum(y => y.Assists),
                                    AverageRating = x.Average(y => y.Rating),
                                    TotalPasses = x.Sum(y => y.PassesCompleted)
                                }).FirstOrDefault();

                var playerInfo = _context.MatchPerformances
                                           .Where(mp => mp.IsActive && mp.MatchId == matchId)
                                           .Select(x => new
                                           {
                                               PlayerRating = x.Player.AverageRating,
                                               PlayerName = x.Player.Name
                                           }).ToList();

                var matchSummary = new
                {
                    TotalGoals = matchDetails.TotalGoals,
                    TotalAssists = matchDetails.TotalAssists,
                    AverageRating = matchDetails.AverageRating,
                    TotalPasses = matchDetails.TotalPasses,
                    PlayerInfo = playerInfo
                };

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Match summary.",
                    Data = matchSummary
                };
            }
            catch (Exception ex)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = $"Following error occured {ex.Message}"
                };
            }


        }


        public ResponseData GetTeamSummary(string teamName)
        {
            teamName = teamName.ToLower();

            try
            {
                var matches = _context.Matches.Where(x => x.HomeTeam.Contains(teamName) || x.AwayTeam.Contains(teamName)).ToList();
                var avgRating = _context.MatchPerformances.Where(x => x.Player.CurrentTeam.ToLower() == teamName).Select(x => x.Rating).Average();

                int goalsScored = 0;
                int goalsConceaded = 0;

                foreach(var match in matches)
                {
                    if(match.HomeTeam.Contains(teamName))
                    {
                        goalsScored = match.HomeScore + goalsScored;
                        goalsConceaded = match.AwayScore + goalsConceaded;
                    }
                    else
                    {
                        goalsScored = match.AwayScore + goalsScored;
                        goalsConceaded = match.HomeScore + goalsConceaded;
                    }
                }

                var teamSummary = new
                {
                    TotalMatches = matches.Count(),
                    TotalGoalsScored = goalsScored,
                    TotalGoalsConceaded = goalsConceaded,
                    AverageRating = avgRating
                };

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "TeamDto summary.",
                    Data = teamSummary
                };
            }
            catch (Exception ex)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = $"Following error occured {ex.Message}"
                };
            }
        }
    }
}
