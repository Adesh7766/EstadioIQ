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
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _service;

        public MatchController(IMatchService service)
        {
            _service = service;
        }

        [HttpGet("GetAllMatches")]        
        public ResponseData<List<MatchDto>> GetMatches()
        {
            var response = _service.GetMatches();

            return new ResponseData<List<MatchDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }


        [HttpGet("GetMatchById")]
        public ResponseData<MatchDto> GetMatchById(int id)
        {
            var response = _service.GetMatchById(id);

            return new ResponseData<MatchDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("UpdateMatch")]
        public ResponseData UpdateMatch([FromBody] MatchDto Match)
        {
            var response = _service.UpdateMatch(Match);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpGet("DeleteMatch")]
        public ResponseData DeleteMatch(int id)
        {
            var response = _service.DeleteMatch(id);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("AddMatch")]
        public ResponseData AddMatch([FromBody] MatchDto match)
        {
            var response = _service.AddMatch(match);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
