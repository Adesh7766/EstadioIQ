using EstadioIQ.DAL;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Helper.AuthHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstadioIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly AuthHelper _authHelper;

        public AuthController(ApplicationDbContext dbContext, IConfiguration configuration, AuthHelper authHelper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _authHelper = authHelper;
        }

        [HttpPost("login")]
        public ResponseData Login([FromBody] LoginDto user)
        {

            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var userFromDb = _dbContext.Users.
                                Where(u => u.Email == user.Email && u.PasswordHash == user.Password)
                                .FirstOrDefault();

            if(userFromDb == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Invalid Credentials."
                };
            }

            var token = _authHelper.GenerateJWTToken(userFromDb);

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "User authenticated.",
                Data = token
            };
        }

    }
}
