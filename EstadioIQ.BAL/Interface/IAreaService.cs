using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;

namespace EstadioIQ.BAL.Interface
{
    public interface IAreaService
    {       
        ResponseData<List<AreaDto>> GetAreas();
        ResponseData<AreaDto> GetAreaById(int id);
        ResponseData UpdateArea(AreaDto area);
        ResponseData AddArea(AreaDto area);
    }
}
