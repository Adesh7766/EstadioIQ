using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;

namespace EstadioIQ.BAL.Interface
{
    public interface IMatchService
    {
        ResponseData<List<MatchDto>> GetMatches(string? homeTeam,
                                                       string? awayTeam,
                                                       DateTime? matchDate,
                                                       string? competetion,
                                                       string? venue,
                                                       int page,
                                                       int size);
        ResponseData<MatchDto> GetMatchById(int id);
        ResponseData UpdateMatch(MatchDto match);
        ResponseData DeleteMatch(int id);
        ResponseData AddMatch(MatchDto match);
        ResponseData GetMatchSummary(int matchId);
        ResponseData GetTeamSummary(string teamName);
        ResponseData<List<MatchDto>> GetAllUCLMatches(int methodId);
    }
}
