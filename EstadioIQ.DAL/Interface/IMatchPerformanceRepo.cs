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
    public interface IMatchPerformanceRepo
    {
        ResponseData<List<MatchPerformanceDto>> GetMatchPerformances();
        ResponseData<MatchPerformanceDto> GetMatchPerformanceById(int id);
        ResponseData UpdateMatchPerformance(MatchPerformance matchPerformance);
        ResponseData DeleteMatchPerformance(int id);
        ResponseData AddMatchPerformance(MatchPerformance matchPerformance);
        ResponseData<List<PlayerDto>> GetBestPerformingPlayers(int minMatches, string position, int page, int size);
        ResponseData GetPlayerWithMostGA();
        ResponseData<List<PlayerFormDto>> GetPlayerForm(int numberOfMatches, int id);
    }
}
