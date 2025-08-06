using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Repository
{
    public class CompetitionRepo : ICompetitionRepo
    {
        private readonly ApplicationDbContext _context;

        public CompetitionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<Competition>> GetCompetitions()
        {
            var competitions = _context.Competitions.ToList();

            if (competitions != null)
            {
                return new ResponseData<List<Competition>>
                {
                    SuccessStatus = true,
                    Message = "All availablke Competitions",
                    Data = Competitions
                };
            }

            return new ResponseData<List<Competition>>
            {
                SuccessStatus = false,
                Message = "Error fetching data."
            };
        }

        public ResponseData<Competition> GetCompetitionById(int id)
        {
            var Competition = _context.Competitions.Where(x => x.Id == id).FirstOrDefault();

            if (Competition == null)
            {
                return new ResponseData<Competition>
                {
                    SuccessStatus = false,
                    Message = "Competition not found."
                };
            }

            return new ResponseData<Competition>
            {
                SuccessStatus = true,
                Message = "Competition found successfully.",
                Data = Competition
            };
        }

        public ResponseData UpdateCompetition(Competition Competition)
        {
            var dbData = _context.Competitions.Where(x => x.Id == Competition.Id).FirstOrDefault();

            if (dbData != null)
            {
                dbData.Name = Competition.Name;
                dbData.Code = Competition.Code;
                dbData.Type = Competition.Type;
                dbData.Emblem = Competition.Emblem;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Competition updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "Competition not found."
            };
        }

        public ResponseData AddCompetition(Competition Competition)
        {
            if (Competition.Name == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Name is required."
                };
            }
            else if (Competition.Code == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Code is required."
                };
            }
            else if (Competition.Type == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Type is required."
                };
            }

            _context.Competitions.Add(Competition);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Competition Added successfully."
            };
        }
    }
}
