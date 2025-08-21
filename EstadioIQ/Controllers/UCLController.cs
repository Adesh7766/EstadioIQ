using EstadioIQ.BAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.DTO.APIResponseDTO;
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
        private readonly IClubService _clubService;

        public UCLController(IMatchService service, IClubService clubService)
        {
            _service = service;
            _clubService = clubService;
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

        [HttpGet("GetAllUCLTeams")]
        public ResponseData<List<ClubDto>> GetTeams()
        {
            var response = _clubService.GetClubsFromAPI(1);

            return new ResponseData<List<ClubDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
