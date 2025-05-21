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
        ResponseData<List<PlayerDto>> GetPlayers(string? name,
                                                string? position,
                                                string? nationality,
                                                int? minAge,
                                                int? maxAge,
                                                double? minRating,
                                                int page,
                                                int size);

        ResponseData<PlayerDto> GetPlayerById(int id);

        ResponseData UpdatePlayer(PlayerDto Player);

        ResponseData DeletePlayer(int id);

        ResponseData AddPlayer(PlayerDto Player);

    }
}
