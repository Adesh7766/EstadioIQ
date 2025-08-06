using EstadioIQ.BAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstadioIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _service;

        public SeasonController(ISeasonService service)
        {
            _service = service;
        }

        [HttpGet("GetAllSeason")]
        public ResponseData<List<SeasonDto>> GetSeason()
        {
            var response = _service.GetSeasons();

            return new ResponseData<List<SeasonDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data,
                TotalCount = response.TotalCount
            };
        }


        [HttpGet("GetSeasonById")]
        public ResponseData<SeasonDto> GetSeasonById(int id)
        {
            var response = _service.GetSeasonById(id);

            return new ResponseData<SeasonDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("UpdateSeason")]
        public ResponseData UpdateSeason([FromForm] SeasonDto Season)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.UpdateSeason(Season);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("AddSeason")]
        public ResponseData AddSeason([FromForm] SeasonDto Season)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.AddSeason(Season);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
