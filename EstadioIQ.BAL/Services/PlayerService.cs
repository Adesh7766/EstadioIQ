using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.BAL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepo _repo;

        public PlayerService(IPlayerRepo repo)
        {
            _repo = repo;
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
            var response = _repo.GetPlayers(name,
                                            position,
                                            nationality,
                                            minAge,
                                            maxAge,
                                            minRating,
                                            page,
                                            size);

            return new ResponseData<List<PlayerDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data,
                TotalCount = response.TotalCount
            };
        }


        public ResponseData<PlayerDto> GetPlayerById(int id)
        {
            var response = _repo.GetPlayerById(id);

            return new ResponseData<PlayerDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        public ResponseData UpdatePlayer(PlayerDto player)
        {
            Player dbData = new Player
            {
                Name = player.Name,
                Age = player.Age,
                Nationality = player.Nationality,
                Position = player.Position,
                CurrentTeam = player.CurrentTeam,
                TotalGoals = player.TotalGoals,
                TotalAssists = player.TotalAssists,
                MatchesPlayed = player.MatchesPlayed,
                AverageRating = player.AverageRating,
                PassAccuracy = player.PassAccuracy,
                PhotoUrl = player.PhotoUrl
            };

            var response = _repo.UpdatePlayer(dbData);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData DeletePlayer(int id)
        {
            var response = _repo.DeletePlayer(id);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData AddPlayer(PlayerDto player)
        {
            Player dbPlayer = new Player
            {
                Name = player.Name,
                Age = player.Age,
                Nationality = player.Nationality,
                Position = player.Position,
                CurrentTeam = player.CurrentTeam,
                TotalGoals = player.TotalGoals,
                TotalAssists = player.TotalAssists,
                MatchesPlayed = player.MatchesPlayed,
                AverageRating = player.AverageRating,
                PassAccuracy = player.PassAccuracy,
                IsActive = true,
                PhotoUrl = player.PhotoUrl
            };

            var response = _repo.AddPlayer(dbPlayer);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }
    }
}
