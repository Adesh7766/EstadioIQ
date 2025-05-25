using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Repository
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<PlayerDto>> GetPlayers(
                                                string? name,
                                                string? position,
                                                string? nationality,
                                                int? minAge,
                                                int? maxAge,
                                                double? minRating,
                                                int page,
                                                int size)
        {
            var query = _context.Players.Where(x => x.IsActive == true);


            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name.Contains(name));

            if (!string.IsNullOrEmpty(position))
                query = query.Where(x => x.Position.Contains(position));

            if (!string.IsNullOrEmpty(nationality))
                query = query.Where(x => x.Nationality.Contains(nationality));

            if (minAge.HasValue)
                query = query.Where(x => x.Age >= minAge);

            if (maxAge.HasValue)
                query = query.Where(x => x.Age <= maxAge);

            if (minRating.HasValue)
                query = query.Where(x => x.AverageRating >= minRating);

            int totalCount = query.Count();

            var players = query
                .Skip((page - 1) * size)
                .Take(size)
                .Select(x => new PlayerDto
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Nationality = x.Nationality,
                Position = x.Position,
                CurrentTeam = x.CurrentTeam,
                TotalGoals = x.TotalGoals,
                TotalAssists = x.TotalAssists,
                MatchesPlayed = x.MatchesPlayed,
                AverageRating = x.AverageRating,
                PassAccuracy = x.PassAccuracy,
                PhotoUrl = x.PhotoUrl
            }).ToList();

            return new ResponseData<List<PlayerDto>>
            {
                SuccessStatus = true,
                Message = $"Page {page} of all players.",
                Data = players,
                TotalCount = totalCount
            };
        }

        public ResponseData<PlayerDto> GetPlayerById(int id)
        {
            var player = _context.Players.Where(x => x.IsActive == true && x.Id == id).Select(x => new PlayerDto
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Nationality = x.Nationality,
                Position = x.Position,
                CurrentTeam = x.CurrentTeam,
                TotalGoals = x.TotalGoals,
                TotalAssists = x.TotalAssists,
                MatchesPlayed = x.MatchesPlayed,
                AverageRating = x.AverageRating,
                PassAccuracy = x.PassAccuracy,
                PhotoUrl = x.PhotoUrl
            }).FirstOrDefault();

            if (player == null)
            {
                return new ResponseData<PlayerDto>
                {
                    SuccessStatus = false,
                    Message = "Player not found."
                };
            }

            return new ResponseData<PlayerDto>
            {
                SuccessStatus = true,
                Message = "Player found successfully.",
                Data = player
            };
        }

        public ResponseData UpdatePlayer(Player player)
        {
            var dbData = _context.Players.Where(x => x.IsActive == true && x.Id == player.Id).FirstOrDefault();

            if (dbData != null)
            {
                dbData.Name = player.Name;
                dbData.Age = player.Age;
                dbData.Nationality = player.Nationality;
                dbData.Position = player.Position;
                dbData.CurrentTeam = player.CurrentTeam;
                dbData.TotalGoals = player.TotalGoals;
                dbData.TotalAssists = player.TotalAssists;
                dbData.MatchesPlayed = player.MatchesPlayed;
                dbData.AverageRating = player.AverageRating;
                dbData.PassAccuracy = player.PassAccuracy;
                dbData.PhotoUrl = player.PhotoUrl;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Player updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "Player not found."
            };
        }

        public ResponseData DeletePlayer(int id)
        {
            var player = _context.Players.Where(x => x.IsActive == true).FirstOrDefault();

            if (player == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Player not found."
                };
            }

            player.IsActive = false;

            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Player deleted successfully.",
            };
        }

        public ResponseData AddPlayer(Player player)
        {
            if (player.Name == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Name is required."
                };
            }
            else if (player.Age == 0)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Age is required."
                };
            }
            else if (player.Nationality == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Nationality is required."
                };
            }

            _context.Players.Add(player);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Player Added successfully."
            };
        }               
    }
}
