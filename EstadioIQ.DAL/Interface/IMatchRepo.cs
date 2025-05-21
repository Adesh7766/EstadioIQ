using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Interface
{
    public interface IMatchRepo
    {
        ResponseData<List<MatchDto>> GetMatches(string? homeTeam,
                                                string? awayTeam,
                                                DateTime? matchDate,
                                                string? competetion,
                                                string? venue,
                                                int page,
                                                int size);
        ResponseData<MatchDto> GetMatchById(int id);
        ResponseData UpdateMatch(Match match);
        ResponseData DeleteMatch(int id);
        ResponseData AddMatch(Match match);
    }
}
