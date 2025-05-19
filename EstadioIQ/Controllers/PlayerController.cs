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
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        [HttpGet("GetAllPlayers")]
        [Authorize]
        public ResponseData<List<PlayerDto>> GetPlayers()
        {
            var response = _service.GetPlayers();

            return new ResponseData<List<PlayerDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }


        [HttpGet("GetPlayerById")]
        public ResponseData<PlayerDto> GetPlayerById(int id)
        {
            var response = _service.GetPlayerById(id);

            return new ResponseData<PlayerDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("UpdatePlayer")]
        public ResponseData UpdatePlayer([FromBody] PlayerDto Player)
        {
            var response = _service.UpdatePlayer(Player);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpGet("DeletePlayer")]
        public ResponseData DeletePlayer(int id)
        {
            var response = _service.DeletePlayer(id);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("AddPlayer")]
        public ResponseData AddPlayer([FromBody] PlayerDto player)
        {
            var response = _service.AddPlayer(player);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
