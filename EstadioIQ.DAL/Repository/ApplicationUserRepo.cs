using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Repository
{
    public class ApplicationUserRepo : IApplicationUserRepo
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData<List<UserDto>> GetUsers()
        {
            var users = _context.Users.Where(x => x.IsActive == true).Select(x => new UserDto
            {
                Id = x.Id,
                Username = x.UserName,
                Email = x.Email,
                Role = x.Role,
                CreatedAt = x.CreatedDate
            }).ToList();

            return new ResponseData<List<UserDto>>
            {
                SuccessStatus = true,
                Message = "List of all users.",
                Data = users
            };
        }

        public ResponseData<UserDto> GetUserById(int id)
        {
            var user = _context.Users.Where(x => x.IsActive == true && x.Id == id).Select(x => new UserDto
            {
                Id = x.Id,
                Username = x.UserName,
                Email = x.Email,
                Role = x.Role,
                CreatedAt = x.CreatedDate
            }).FirstOrDefault();

            if(user == null)
            {
                return new ResponseData<UserDto>
                {
                    SuccessStatus = false,
                    Message = "User not found."
                };
            }

            return new ResponseData<UserDto>
            {
                SuccessStatus = true,
                Message = "User found successfully.",
                Data = user
            };
        }

        public ResponseData UpdateUser(ApplicationUser user)
        {
            var dbData = _context.Users.Where(x => x.IsActive == true && x.Id == user.Id).FirstOrDefault();

            if (dbData != null)
            {
                dbData.UserName = user.UserName;
                dbData.Email = user.Email;
                dbData.Role = user.Role;

                _context.SaveChanges();

                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "User updated successfully."
                };
            }

            return new ResponseData
            {
                SuccessStatus = false,
                Message = "User not found."
            };
        }

        public ResponseData DeleteUser(int id)
        {
            var user = _context.Users.Where(x => x.IsActive == true).FirstOrDefault();
            
            if (user == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "user not found."
                };
            }

            user.IsActive = false;

            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "User deleted successfully.",
            };
        }

        public ResponseData RegisterUser(ApplicationUser user)
        {
            if(user.UserName == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "UserName is required."
                };
            }
            else if (user.Email == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Email is required."
                };
            }
            else if (user.PasswordHash == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Password is required."
                };
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResponseData
            {
                SuccessStatus = true,
                Message = "User registered successfully."
            };
        }
    }
}
