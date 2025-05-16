using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.BAL.Interface
{
    public interface IApplicationUserService
    {
        ResponseData<List<UserDto>> GetUsers();

        ResponseData<UserDto> GetUserById(int id);

        ResponseData UpdateUser(UserDto user);

        ResponseData DeleteUser(int id);

        ResponseData RegisterUser(RegisterDto user); 
    }
}
