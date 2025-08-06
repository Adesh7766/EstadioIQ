using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;

namespace EstadioIQ.BAL.Interface
{
    public interface ISeasonService
    {
        ResponseData<List<SeasonDto>> GetSeasons();
        ResponseData<SeasonDto> GetSeasonById(int id);
        ResponseData UpdateSeason(SeasonDto Season);
        ResponseData AddSeason(SeasonDto Season);
    }
}
