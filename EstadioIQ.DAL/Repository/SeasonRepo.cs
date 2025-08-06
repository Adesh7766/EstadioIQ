using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Repository
{
    public class SeasonRepo : ISeasonRepo
    {
        private readonly ApplicationDbContext _context;

        public SeasonRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<Season>> GetSeasons()
        {
            var Seasons = _context.Seasons.ToList();

            if (Seasons != null)
            {
                return new ResponseData<List<Season>>
                {
                    SuccessStatus = true,
                    Message = "All availablke Seasons",
                    Data = Seasons
                };
            }

            return new ResponseData<List<Season>>
            {
                SuccessStatus = false,
                Message = "Error fetching data."
            };
        }

        public ResponseData<Season> GetSeasonById(int id)
        {
            var Season = _context.Seasons.Where(x => x.Id == id).FirstOrDefault();

            if (Season == null)
            {
                return new ResponseData<Season>
                {
                    SuccessStatus = false,
                    Message = "Season not found."
                };
            }

            return new ResponseData<Season>
            {
                SuccessStatus = true,
                Message = "Season found successfully.",
                Data = Season
            };
        }

        public ResponseData UpdateSeason(Season Season)
        {
            var dbData = _context.Seasons.Where(x => x.Id == Season.Id).FirstOrDefault();

            if (dbData != null)
            {
                dbData.StartDate = Season.StartDate;
                dbData.EndDate = Season.EndDate;
                dbData.CurrentMatchday = Season.CurrentMatchday;
                dbData.Winner = Season.Winner;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Season updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "Season not found."
            };
        }

        public ResponseData AddSeason(Season Season)
        {
            if (Season.StartDate == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "StartDate is required."
                };
            }
            else if (Season.EndDate == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "EndDate is required."
                };
            }
            else if (Season.CurrentMatchday == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "CurrentMatchday is required."
                };
            }
            else if (Season.Winner == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Winner is required."
                };
            }

            _context.Seasons.Add(Season);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Season Added successfully."
            };
        }
    }
}
