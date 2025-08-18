using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Interface
{
    public interface IClubRepo
    {
        ResponseData<List<Club>> GetClubs();
        ResponseData<Club> GetClubById(int id);
        ResponseData UpdateClub(Club club);
        ResponseData AddClub(Club club);
    }
}
