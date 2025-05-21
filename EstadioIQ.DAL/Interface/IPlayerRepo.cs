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
        ResponseData<List<PlayerDto>> GetPlayers(string? name,
                                                string? position,
                                                string? nationality,
                                                int? minAge,
                                                int? maxAge,
                                                double? minRating,
                                                int page,
                                                int size);
        ResponseData<PlayerDto> GetPlayerById(int id);
        ResponseData UpdatePlayer(Player player);
        ResponseData DeletePlayer(int id);
        ResponseData AddPlayer(Player player);
    }
}
