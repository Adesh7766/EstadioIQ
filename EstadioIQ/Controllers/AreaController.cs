using EstadioIQ.BAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using Microsoft.AspNetCore.Mvc;

namespace EstadioIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _service;

        public AreaController(IAreaService service)
        {
            _service = service;
        }

        [HttpGet("GetAllArea")]
        public ResponseData<List<AreaDto>> GetArea()
        {
            var response = _service.GetAreas();

            return new ResponseData<List<AreaDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data,
                TotalCount = response.TotalCount
            };
        }


        [HttpGet("GetAreaById")]
        public ResponseData<AreaDto> GetAreaById(int id)
        {
            var response = _service.GetAreaById(id);

            return new ResponseData<AreaDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("UpdateArea")]
        public ResponseData UpdateArea([FromForm] AreaDto Area)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.UpdateArea(Area);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("AddArea")]
        public ResponseData AddArea([FromForm] AreaDto Area)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.AddArea(Area);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
