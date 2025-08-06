using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Repository
{
    public class RefreeRepo : IRefreeRepo
    {
        private readonly ApplicationDbContext _context;

        public RefreeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<Refree>> GetRefrees()
        {
            var Refrees = _context.Refrees.ToList();

            if (Refrees != null)
            {
                return new ResponseData<List<Refree>>
                {
                    SuccessStatus = true,
                    Message = "All availablke Refrees",
                    Data = Refrees
                };
            }

            return new ResponseData<List<Refree>>
            {
                SuccessStatus = false,
                Message = "Error fetching data."
            };
        }

        public ResponseData<Refree> GetRefreeById(int id)
        {
            var Refree = _context.Refrees.Where(x => x.Id == id).FirstOrDefault();

            if (Refree == null)
            {
                return new ResponseData<Refree>
                {
                    SuccessStatus = false,
                    Message = "Refree not found."
                };
            }

            return new ResponseData<Refree>
            {
                SuccessStatus = true,
                Message = "Refree found successfully.",
                Data = Refree
            };
        }

        public ResponseData UpdateRefree(Refree Refree)
        {
            var dbData = _context.Refrees.Where(x => x.Id == Refree.Id).FirstOrDefault();

            if (dbData != null)
            {
                dbData.Name = Refree.Name;
                dbData.Type = Refree.Type;
                dbData.Nationality = Refree.Nationality;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Refree updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "Refree not found."
            };
        }

        public ResponseData AddRefree(Refree Refree)
        {
            if (Refree.Name == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Name is required."
                };
            }
            else if (Refree.Nationality == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Nationality is required."
                };
            }
            else if (Refree.Type == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Type is required."
                };
            }

            _context.Refrees.Add(Refree);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Refree Added successfully."
            };
        }
    }
}
