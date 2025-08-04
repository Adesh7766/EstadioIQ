using EstadioIQ.BAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstadioIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UCLController : ControllerBase
    {
        private readonly IMatchService _service;

        public UCLController(IMatchService service)
        {
            _service = service;
        }

        [HttpGet("GetAllUCLMatches")]
        public ResponseData<List<MatchDto>> GetMatches()
        {
            var response = _service.GetAllUCLMatches(1);

            return new ResponseData<List<MatchDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
