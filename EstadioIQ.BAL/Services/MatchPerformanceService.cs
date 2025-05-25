using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.BAL.Services
{
    public class MatchPerformanceService : IMatchPerformanceService
    {
        private readonly IMatchPerformanceRepo _repo;

        public MatchPerformanceService(IMatchPerformanceRepo repo)
        {
            _repo = repo;
        }

        public ResponseData<List<MatchPerformanceDto>> GetMatchPerformances()
        {
            var response = _repo.GetMatchPerformances();

            return new ResponseData<List<MatchPerformanceDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }


        public ResponseData<MatchPerformanceDto> GetMatchPerformanceById(int id)
        {
            var response = _repo.GetMatchPerformanceById(id);

            return new ResponseData<MatchPerformanceDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        public ResponseData UpdateMatchPerformance(MatchPerformanceDto matchPerformance)
        {
            MatchPerformance dbData = new MatchPerformance
            {
                MatchId = matchPerformance.MatchId,
                PlayerId = matchPerformance.PlayerId,
                Goals = matchPerformance.Goals,
                Assists = matchPerformance.Assists,
                PassesCompleted = matchPerformance.PassesCompleted,
                Rating = matchPerformance.Rating,
                IsActive = matchPerformance.IsActive,
                IsStarter = matchPerformance.IsStarter,
                MinutesPlayed = matchPerformance.MinutesPlayed
            };

            var response = _repo.UpdateMatchPerformance(dbData);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData DeleteMatchPerformance(int id)
        {
            var response = _repo.DeleteMatchPerformance(id);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData AddMatchPerformance(MatchPerformanceDto matchPerformance)
        {
            MatchPerformance dbData = new MatchPerformance
            {
                MatchId = matchPerformance.MatchId,
                PlayerId = matchPerformance.PlayerId,
                Goals = matchPerformance.Goals,
                Assists = matchPerformance.Assists,
                PassesCompleted = matchPerformance.PassesCompleted,
                Rating = matchPerformance.Rating,
                IsActive = matchPerformance.IsActive,
                IsStarter = matchPerformance.IsStarter,
                MinutesPlayed = matchPerformance.MinutesPlayed
            };

            var response = _repo.AddMatchPerformance(dbData);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData<List<PlayerDto>> GetBestPerformingPlayers(int minMatches, string position, int page, int size)
        {
            var resoponse = _repo.GetBestPerformingPlayers(minMatches, position, page, size);

            return new ResponseData<List<PlayerDto>>
            {
                SuccessStatus = resoponse.SuccessStatus,
                Message = resoponse.Message,
                Data = resoponse.Data
            };
        }
    }
}
