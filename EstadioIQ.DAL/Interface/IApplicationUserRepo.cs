using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.DAL.Interface
{
    public interface IApplicationUserRepo
    {
        ResponseData<List<UserDto>> GetUsers();
        ResponseData<UserDto> GetUserById(int id);
        ResponseData UpdateUser(ApplicationUser user);
        ResponseData DeleteUser(int id);
        ResponseData RegisterUser(ApplicationUser user);
    }
}
