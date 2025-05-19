using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.BAL.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepo _repo;

        public MatchService(IMatchRepo repo)
        {
            _repo = repo;
        }

        public ResponseData<List<MatchDto>> GetMatches()
        {
            var response = _repo.GetMatches();

            return new ResponseData<List<MatchDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }


        public ResponseData<MatchDto> GetMatchById(int id)
        {
            var response = _repo.GetMatchById(id);

            return new ResponseData<MatchDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        public ResponseData UpdateMatch(MatchDto match)
        {
            Match dbData = new Match
            {
                HomeTeam = match.HomeTeam,
                AwayTeam = match.AwayTeam,
                MatchDate = match.MatchDate,
                Competition = match.Competition,
                HomeScore = match.HomeScore,
                AwayScore = match.AwayScore,
                IsActive = match.IsActive,
                Venue = match.Venue
            };

            var response = _repo.UpdateMatch(dbData);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData DeleteMatch(int id)
        {
            var response = _repo.DeleteMatch(id);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData AddMatch(MatchDto match)
        {
            Match dbData = new Match
            {
                HomeTeam = match.HomeTeam,
                AwayTeam = match.AwayTeam,
                MatchDate = match.MatchDate,
                Competition = match.Competition,
                HomeScore = match.HomeScore,
                AwayScore = match.AwayScore,
                IsActive = match.IsActive,
                Venue = match.Venue
            };

            var response = _repo.AddMatch(dbData);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }
    }
}
