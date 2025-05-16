using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Interface
{
    public interface IPlayerRepo
    {
        ResponseData<List<PlayerDto>> GetPlayers();
        ResponseData<PlayerDto> GetPlayerById(int id);
        ResponseData UpdatePlayer(Player player);
        ResponseData DeletePlayer(int id);
        ResponseData AddPlayer(Player player);
    }
}
