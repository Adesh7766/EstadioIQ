using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Repository
{
    public class AreaRepo : IAreaRepo
    {
        private readonly ApplicationDbContext _context;

        public AreaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<Area>> GetAreas()
        {
            var areas = _context.Areas.ToList();

            if (areas != null)
            {
                return new ResponseData<List<Area>>
                {
                    SuccessStatus = true,
                    Message = "All availablke areas",
                    Data = areas
                };
            }

            return new ResponseData<List<Area>>
            {
                SuccessStatus = false,
                Message = "Error fetching data."
            };
        }

        public ResponseData<Area> GetAreaById(int id)
        {
            var area = _context.Areas.Where(x => x.Id == id).FirstOrDefault();

            if (area == null)
            {
                return new ResponseData<Area>
                {
                    SuccessStatus = false,
                    Message = "Area not found."
                };
            }

            return new ResponseData<Area>
            {
                SuccessStatus = true,
                Message = "Area found successfully.",
                Data = area
            };
        }

        public ResponseData UpdateArea(Area area)
        {
            var dbData = _context.Areas.Where(x => x.Id == area.Id).FirstOrDefault();

            if (dbData != null)
            {
                dbData.Name = area.Name;
                dbData.Code = area.Code;
                dbData.Flag = area.Flag;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Area updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "Area not found."
            };
        }

        public ResponseData AddArea(Area area)
        {
            if (area.Name == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Name is required."
                };
            }
            else if (area.Code == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Code is required."
                };
            }
            else if (area.Flag == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Flag is required."
                };
            }

            _context.Areas.Add(area);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Area Added successfully."
            };
        }
    }
}
