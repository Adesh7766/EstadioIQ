using EstadioIQ.BAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstadioIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatchPerformanceController : ControllerBase
    {
        private readonly IMatchPerformanceService _service;

        public MatchPerformanceController(IMatchPerformanceService service)
        {
            _service = service;
        }

        [HttpGet("GetAllMatchPerformances")]
        public ResponseData<List<MatchPerformanceDto>> GetMatchPerformances()
        {
            var response = _service.GetMatchPerformances();

            return new ResponseData<List<MatchPerformanceDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }


        [HttpGet("GetMatchPerformanceById")]
        public ResponseData<MatchPerformanceDto> GetMatchPerformanceById(int id)
        {
            var response = _service.GetMatchPerformanceById(id);

            return new ResponseData<MatchPerformanceDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("UpdateMatchPerformance")]
        public ResponseData UpdateMatchPerformance([FromBody] MatchPerformanceDto matchPerformance)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.UpdateMatchPerformance(matchPerformance);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpGet("DeleteMatchPerformance")]
        public ResponseData DeleteMatchPerformance(int id)
        {
            var response = _service.DeleteMatchPerformance(id);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("AddMatchPerformance")]
        public ResponseData AddMatchPerformance([FromBody] MatchPerformanceDto matchPerformance)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.AddMatchPerformance(matchPerformance);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("BestPerformingPlayers")]
        public ResponseData<List<PlayerDto>> GetBestPerformingPlayers(int minMatches, string position, int page = 1, int size = 10)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData<List<PlayerDto>>
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.GetBestPerformingPlayers(minMatches, position, page, size);

            return new ResponseData<List<PlayerDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
