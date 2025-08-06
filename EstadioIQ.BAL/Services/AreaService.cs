using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;
using EstadioIQ.Helper.Converter;

namespace EstadioIQ.BAL.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepo _repo;
        private readonly AreaConverter _converter;

        public AreaService(IAreaRepo repo, AreaConverter converter)
        {
            _repo = repo;
            _converter = converter;
        }

        public ResponseData<List<AreaDto>> GetAreas()
        {
            var response = _repo.GetAreas();

            List<AreaDto> Areas = new List<AreaDto>();

            foreach (var area in response.Data)
            {
                var data = _converter.ConvertToDto(area);

                Areas.Add(data);
            }

            return new ResponseData<List<AreaDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Areas,
                TotalCount = response.TotalCount
            };
        }


        public ResponseData<AreaDto> GetAreaById(int id)
        {
            var response = _repo.GetAreaById(id);

            AreaDto area = _converter.ConvertToDto(response.Data);

            return new ResponseData<AreaDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = area
            };
        }

        public ResponseData UpdateArea(AreaDto Area)
        {
            var model = _converter.ConvertToModel(Area);

            var response = _repo.UpdateArea(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData AddArea(AreaDto Area)
        {
            var model = _converter.ConvertToModel(Area);

            var response = _repo.AddArea(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }
    }
}
