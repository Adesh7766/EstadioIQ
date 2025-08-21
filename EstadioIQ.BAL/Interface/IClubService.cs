using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;

namespace EstadioIQ.BAL.Interface
{
    public interface IClubService
    {
        ResponseData<List<ClubDto>> GetClubs();
        ResponseData<ClubDto> GetClubById(int id);
        ResponseData UpdateClub(ClubDto Club);
        ResponseData AddClub(ClubDto Club);
        ResponseData<List<ClubDto>> GetClubsFromAPI(int methodId);
    }
}
