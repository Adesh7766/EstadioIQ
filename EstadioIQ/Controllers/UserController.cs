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
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserService _service;

        public UserController(IApplicationUserService service)
        {
            _service = service;
        }

        [HttpGet("GetAllUsers")]
        [Authorize]
        public ResponseData<List<UserDto>> GetUsers()
        {
            var response = _service.GetUsers();

            return new ResponseData<List<UserDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }


        [HttpGet("GetUserById")]
        public ResponseData<UserDto> GetUserById(int id)
        {
            var response = _service.GetUserById(id);

            return new ResponseData<UserDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("UpdateUser")]
        public ResponseData UpdateUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.UpdateUser(user);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpGet("DeleteUser")]
        public ResponseData DeleteUser(int id)
        {
            var response = _service.DeleteUser(id);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("RegisterUser")]
        public ResponseData RegisterUser([FromBody] RegisterDto user)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.RegisterUser(user);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
