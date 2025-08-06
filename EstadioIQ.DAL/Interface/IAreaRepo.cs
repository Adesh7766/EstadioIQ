using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Interface
{
    public interface IAreaRepo 
    {
        ResponseData<List<Area>> GetAreas();
        ResponseData<Area> GetAreaById(int id);
        ResponseData UpdateArea(Area area);
        ResponseData AddArea(Area area);
    }
}
