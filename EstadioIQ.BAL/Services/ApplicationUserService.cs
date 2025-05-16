using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.BAL.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        IApplicationUserRepo _repo;

        public ApplicationUserService(IApplicationUserRepo repo) 
        {
            _repo = repo;
        }

        public ResponseData<List<UserDto>> GetUsers()
        {
            var response = _repo.GetUsers();

            return new ResponseData<List<UserDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        public ResponseData<UserDto> GetUserById(int id)
        {
            var response = _repo.GetUserById(id);

            return new ResponseData<UserDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        public ResponseData UpdateUser(UserDto user)
        {
            ApplicationUser dbData = new ApplicationUser
            {
                UserName = user.Username,
                Email = user.Email,
                Role = user.Role
            };

            var response = _repo.UpdateUser(dbData);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData DeleteUser(int id)
        {
            var response = _repo.DeleteUser(id);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData RegisterUser(RegisterDto user)
        {
            ApplicationUser dbUser = new ApplicationUser
            {
                UserName = user.Username,
                Email = user.Email,
                PasswordHash = user.Password,
                IsActive = true,
                Role = user.Role,
                CreatedDate = DateTime.Today
            };

            var response = _repo.RegisterUser(dbUser);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }
    }
}
