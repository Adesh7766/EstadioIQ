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
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        [HttpGet("GetAllPlayers")]
        public ResponseData<List<PlayerDto>> GetPlayers(
                                                string? name,
                                                string? position,
                                                string? nationality,
                                                int? minAge,
                                                int? maxAge,
                                                double? minRating,
                                                int page = 1,
                                                int size = 10)
        {
            var response = _service.GetPlayers(name,
                                                position,
                                                nationality,
                                                minAge,
                                                maxAge,
                                                minRating,
                                                page,
                                                size
                                                );

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
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

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
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

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
