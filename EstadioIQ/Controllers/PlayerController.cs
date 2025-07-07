using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure;
using EstadioIQ.BAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace EstadioIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;
        private readonly IWebHostEnvironment _env;

        public PlayerController(IPlayerService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
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
                Data = response.Data,
                TotalCount = response.TotalCount
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
        public async Task<ResponseData> UpdatePlayer([FromForm] PlayerDto Player, IFormFile? image)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            if (image != null && image.Length > 0)
            {
                var uploadFolder = Path.Combine(_env.ContentRootPath, "Uploads", "playerImages");

                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var fileName = Path.GetFileName(image.FileName);

                var filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                Player.PhotoUrl = $"Uploads/playerImages/{fileName}";
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
        public async Task<ResponseData> AddPlayer([FromForm] PlayerDto player, IFormFile? image)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            if(image != null && image.Length > 0)
            {
                var uploadFolder = Path.Combine(_env.ContentRootPath, "Uploads", "playerImages");

                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var fileName = Path.GetFileName(image.FileName);

                var filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                player.PhotoUrl = $"Uploads/playerImages/{fileName}";
            }

            var response = _service.AddPlayer(player);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpGet("ComparePlayers")]
        public ResponseData<List<PlayerDto>> ComparePlayers(int firstPlayerId, int secondPlayerId)
        {
            var firstPlayer = _service.GetPlayerById(firstPlayerId).Data;
            var secondPlayer = _service.GetPlayerById(secondPlayerId).Data;


            if (firstPlayer != null && secondPlayer != null)
            {
                return new ResponseData<List<PlayerDto>>
                {
                    SuccessStatus = true,
                    Message = $"Comparision between {firstPlayer.Name} and {secondPlayer.Name}",
                    Data = new List<PlayerDto> { firstPlayer, secondPlayer }
                };
            }
            else
            {
                return new ResponseData<List<PlayerDto>>
                {
                    SuccessStatus = false,
                    Message = "Players not found."
                };
            }
        }
    }
}
