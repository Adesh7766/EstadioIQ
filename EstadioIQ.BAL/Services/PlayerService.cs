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

        public ResponseData<List<PlayerDto>> GetPlayers()
        {
            var response = _repo.GetPlayers();

            return new ResponseData<List<PlayerDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
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
            Player dbUser = new Player
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

            var response = _repo.AddPlayer(dbUser);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }
    }
}
