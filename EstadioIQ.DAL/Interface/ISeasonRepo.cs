using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Interface
{
    public interface ISeasonRepo
    {
        ResponseData<List<Season>> GetSeasons();
        ResponseData<Season> GetSeasonById(int id);
        ResponseData UpdateSeason(Season Season);
        ResponseData AddSeason(Season Season);
    }
}
