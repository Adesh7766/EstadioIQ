using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;

namespace EstadioIQ.BAL.Interface
{
    public interface ICompetitionService
    {
        ResponseData<List<CompetitionDto>> GetCompetitions();
        ResponseData<CompetitionDto> GetCompetitionById(int id);
        ResponseData UpdateCompetition(CompetitionDto Competition);
        ResponseData AddCompetition(CompetitionDto Competition);
    }
}
