using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;

namespace EstadioIQ.BAL.Interface
{
    public interface IPlayerService
    {
        ResponseData<List<PlayerDto>> GetPlayers();

        ResponseData<PlayerDto> GetPlayerById(int id);

        ResponseData UpdatePlayer(PlayerDto Player);

        ResponseData DeletePlayer(int id);

        ResponseData AddPlayer(PlayerDto Player);

    }
}
