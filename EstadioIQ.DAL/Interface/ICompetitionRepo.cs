using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Interface
{
    public interface ICompetitionRepo
    {
        ResponseData<List<Competition>> GetCompetitions();
        ResponseData<Competition> GetCompetitionById(int id);
        ResponseData UpdateCompetition(Competition competition);
        ResponseData AddCompetition(Competition competition);
    }
}
