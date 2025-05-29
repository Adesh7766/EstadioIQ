using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Repository
{
    public class MatchPerformanceRepo : IMatchPerformanceRepo
    {
        private readonly ApplicationDbContext _context;

        public MatchPerformanceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<MatchPerformanceDto>> GetMatchPerformances()
        {
            var matches = _context.MatchPerformances.Where(x => x.IsActive == true).Select(x => new MatchPerformanceDto
            {
                Id = x.Id,
                MatchId = x.MatchId,
                PlayerId = x.PlayerId,
                Goals = x.Goals,
                Assists = x.Assists,
                PassesCompleted = x.PassesCompleted,
                Rating = x.Rating,
                IsActive = x.IsActive,
                IsStarter = x.IsStarter,
                MinutesPlayed = x.MinutesPlayed
            }).ToList();

            return new ResponseData<List<MatchPerformanceDto>>
            {
                SuccessStatus = true,
                Message = "List of all match performances.",
                Data = matches
            };
        }

        public ResponseData<MatchPerformanceDto> GetMatchPerformanceById(int id)
        {
            var match = _context.MatchPerformances.Where(x => x.IsActive == true && x.Id == id).Select(x => new MatchPerformanceDto
            {
                Id = x.Id,
                MatchId = x.MatchId,
                PlayerId = x.PlayerId,
                Goals = x.Goals,
                Assists = x.Assists,
                PassesCompleted = x.PassesCompleted,
                Rating = x.Rating,
                IsActive = x.IsActive,
                IsStarter = x.IsStarter,
                MinutesPlayed = x.MinutesPlayed
            }).FirstOrDefault();

            if (match == null)
            {
                return new ResponseData<MatchPerformanceDto>
                {
                    SuccessStatus = false,
                    Message = "MatchPerformance not found."
                };
            }

            return new ResponseData<MatchPerformanceDto>
            {
                SuccessStatus = true,
                Message = "MatchPerformance found successfully.",
                Data = match
            };
        }

        public ResponseData UpdateMatchPerformance(MatchPerformance match)
        {
            var dbData = _context.MatchPerformances.Where(x => x.IsActive == true && x.Id == match.Id).FirstOrDefault();

            if (dbData != null)
            {

                dbData.MatchId = match.MatchId;
                dbData.Player = match.Player;
                dbData.Goals = match.Goals;
                dbData.Assists = match.Assists;
                dbData.PassesCompleted = match.PassesCompleted;
                dbData.Rating = match.Rating;
                dbData.IsActive = match.IsActive;
                dbData.IsStarter = match.IsStarter;
                dbData.MinutesPlayed = match.MinutesPlayed;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "MatchPerformance updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "MatchPerformance not found."
            };
        }

        public ResponseData DeleteMatchPerformance(int id)
        {
            var player = _context.MatchPerformances.Where(x => x.IsActive == true).FirstOrDefault();

            if (player == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "MatchPerformance not found."
                };
            }

            player.IsActive = false;

            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "MatchPerformance deleted successfully.",
            };
        }

        public ResponseData AddMatchPerformance(MatchPerformance match)
        {
            if (match.MatchId == 0)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Match is required."
                };
            }
            else if (match.PlayerId == 0)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "AwayTeam is required."
                };
            }
            else if (match.Player == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Player is required."
                };
            }
            else if (match.Match == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Match is required."
                };
            }
            else if (match.Rating == 0)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Rating is required."
                };
            }

            _context.MatchPerformances.Add(match);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "MatchPerformance Added successfully."
            };
        }

        public ResponseData<List<PlayerDto>> GetBestPerformingPlayers(int minMatches, string position, int page, int size)
        {
            var topPerformers =  _context.MatchPerformances.Where(x => x.IsActive == true && x.Player.Position.Contains(position) && x.Player.MatchesPlayed >= minMatches)
                                                          .GroupBy(mp => new { mp.PlayerId, mp.Player.Name } )
                                                          .Select(group => new PlayerDto
                                                          {
                                                              Id = group.Key.PlayerId,
                                                              Name = group.Key.Name,
                                                              TotalGoals = group.Sum(mp => mp.Goals),
                                                              TotalAssists = group.Sum(mp => mp.Assists),
                                                              AverageRating = group.Average(mp => mp.Rating),
                                                              TotalScore = group.Sum(mp => mp.Goals * 4 + mp.Assists * 3 + mp.Rating)
                                                          })
                                                          .OrderByDescending(x => x.TotalScore)
                                                          .Skip((page - 1) * size)
                                                          .Take(size)
                                                          .ToList();

            if(topPerformers != null)
            {
                return new ResponseData<List<PlayerDto>>
                {
                    SuccessStatus = true,
                    Message = "Top Performers.",
                    Data = topPerformers
                };
            }

            return new ResponseData<List<PlayerDto>>
            {
                SuccessStatus = false,
                Message = "Data not available, please contact administrator."
            };
        }

        public ResponseData GetPlayerWithMostGA()
        {
            List<PlayerDto> player = _context.MatchPerformances
                                 .GroupBy(x => new { x.PlayerId, x.Player.Name })
                                 .Select(g => new PlayerDto
                                 {
                                     Id = g.Key.PlayerId,
                                     Name = g.Key.Name,
                                     TotalGoals = g.Sum(x => x.Goals),
                                     TotalAssists = g.Sum(x => x.Assists),
                                     TotalGA = g.Sum(x => x.Goals) + g.Sum(x => x.Assists)
                                 }).ToList();
            if (player == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "No data found."
                };
            }

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Player with most G/A.",
                Data = player.Where(max => max.TotalGA == player.Max(x => x.TotalGA)).FirstOrDefault()
            };
        }

        public ResponseData<List<PlayerFormDto>> GetPlayerForm(int numberOfMatches, int id)
        {
            List<PlayerFormDto> playerForm = _context.MatchPerformances.Where(mp => mp.PlayerId == id && mp.Player.IsActive == true)
                                                                 .OrderByDescending(mp => mp.Match.MatchDate)
                                                                 .Select(x => new PlayerFormDto
                                                                 {
                                                                     Id = x.PlayerId,
                                                                     Name = x.Player.Name,
                                                                     TotalGoals = x.Goals,
                                                                     TotalAssists = x.Assists,
                                                                     AverageRating = x.Rating,
                                                                     IsStarter = x.IsStarter,
                                                                     MatchDate = x.Match.MatchDate
                                                                 }).Take(numberOfMatches).ToList();

            if(playerForm.Count == 0)
            {
                return new ResponseData<List<PlayerFormDto>>
                {
                    SuccessStatus = false,
                    Message = "Player not found."
                };
            }

            return new ResponseData<List<PlayerFormDto>>
            {
                SuccessStatus = true,
                Message = $"Player form over {numberOfMatches} matches.",
                Data = playerForm
            };
        }
    }
}
