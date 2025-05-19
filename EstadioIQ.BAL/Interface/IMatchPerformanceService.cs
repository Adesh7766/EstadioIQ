using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.BAL.Interface
{
    public interface IMatchPerformanceService
    {
        ResponseData<List<MatchPerformanceDto>> GetMatchPerformances();
        ResponseData<MatchPerformanceDto> GetMatchPerformanceById(int id);
        ResponseData UpdateMatchPerformance(MatchPerformanceDto matchPerformance);
        ResponseData DeleteMatchPerformance(int id);
        ResponseData AddMatchPerformance(MatchPerformanceDto matchPerformance);
    }
}
