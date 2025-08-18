using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Repository
{
    public class ClubRepo : IClubRepo
    {
        private readonly ApplicationDbContext _context;

        public ClubRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<Club>> GetClubs()
        {
            var Clubs = _context.Clubs.ToList();

            if (Clubs != null)
            {
                return new ResponseData<List<Club>>
                {
                    SuccessStatus = true,
                    Message = "All availablke Clubs",
                    Data = Clubs
                };
            }

            return new ResponseData<List<Club>>
            {
                SuccessStatus = false,
                Message = "Error fetching data."
            };
        }

        public ResponseData<Club> GetClubById(int id)
        {
            var Club = _context.Clubs.Where(x => x.Id == id).FirstOrDefault();

            if (Club == null)
            {
                return new ResponseData<Club>
                {
                    SuccessStatus = false,
                    Message = "Club not found."
                };
            }

            return new ResponseData<Club>
            {
                SuccessStatus = true,
                Message = "Club found successfully.",
                Data = Club
            };
        }

        public ResponseData UpdateClub(Club Club)
        {
            var dbData = _context.Clubs.Where(x => x.Id == Club.Id).FirstOrDefault();

            if (dbData != null)
            {
                dbData.Name = Club.Name;
                dbData.Code = Club.Code;
                dbData.StadiumName = Club.StadiumName;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Club updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "Club not found."
            };
        }

        public ResponseData AddClub(Club Club)
        {
            if (Club.Name == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Name is required."
                };
            }
            else if (Club.Code == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Code is required."
                };
            }
            else if (Club.StadiumName == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Stadium Name is required."
                };
            }

            _context.Clubs.Add(Club);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Club Added successfully."
            };
        }
    }
}
