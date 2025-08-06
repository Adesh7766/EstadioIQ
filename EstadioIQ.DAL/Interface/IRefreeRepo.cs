using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Interface
{
    public interface IRefreeRepo
    {
        ResponseData<List<Refree>> GetRefrees();
        ResponseData<Refree> GetRefreeById(int id);
        ResponseData UpdateRefree(Refree Refree);
        ResponseData AddRefree(Refree Refree);
    }
}
