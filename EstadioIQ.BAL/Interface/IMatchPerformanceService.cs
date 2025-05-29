using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;

namespace EstadioIQ.BAL.Interface
{
    public interface IMatchPerformanceService
    {
        ResponseData<List<MatchPerformanceDto>> GetMatchPerformances();
        ResponseData<MatchPerformanceDto> GetMatchPerformanceById(int id);
        ResponseData UpdateMatchPerformance(MatchPerformanceDto matchPerformance);
        ResponseData DeleteMatchPerformance(int id);
        ResponseData AddMatchPerformance(MatchPerformanceDto matchPerformance);
        ResponseData<List<PlayerDto>> GetBestPerformingPlayers(int minMatches, string position, int page, int size);
        ResponseData GetPlayerWithMostGA();
    }
}
