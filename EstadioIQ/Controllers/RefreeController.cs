using EstadioIQ.BAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstadioIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreeController : ControllerBase
    {
        private readonly IRefreeService _service;

        public RefreeController(IRefreeService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRefree")]
        public ResponseData<List<RefreeDto>> GetRefree()
        {
            var response = _service.GetRefrees();

            return new ResponseData<List<RefreeDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data,
                TotalCount = response.TotalCount
            };
        }


        [HttpGet("GetRefreeById")]
        public ResponseData<RefreeDto> GetRefreeById(int id)
        {
            var response = _service.GetRefreeById(id);

            return new ResponseData<RefreeDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("UpdateRefree")]
        public ResponseData UpdateRefree([FromForm] RefreeDto Refree)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.UpdateRefree(Refree);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("AddRefree")]
        public ResponseData AddRefree([FromForm] RefreeDto Refree)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.AddRefree(Refree);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
