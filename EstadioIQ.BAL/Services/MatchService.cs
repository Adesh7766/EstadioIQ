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

        public ResponseData<List<MatchDto>> GetMatches(string? homeTeam,
                                                string? awayTeam,
                                                DateTime? matchDate,
                                                string? competetion,
                                                string? venue,
                                                int page,
                                                int size)
        {
            var response = _repo.GetMatches(homeTeam,
                                            awayTeam,
                                            matchDate,
                                            competetion,
                                            venue,
                                            page,
                                            size);

            return new ResponseData<List<MatchDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data,
                TotalCount = response.TotalCount
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
                Id = match.Id,
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

        public ResponseData GetMatchSummary(int matchId)
        {
            var response = _repo.GetMatchSummary(matchId);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
