using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;

namespace EstadioIQ.BAL.Interface
{
    public interface IRefreeService
    {
        ResponseData<List<RefreeDto>> GetRefrees();
        ResponseData<RefreeDto> GetRefreeById(int id);
        ResponseData UpdateRefree(RefreeDto Refree);
        ResponseData AddRefree(RefreeDto Refree);
    }
}
