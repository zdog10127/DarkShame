using API.DarkShame.Domain.Dto.Request.Users;
using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Users
{
    public interface IServiceUser
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserId(string idUser);
        Task<ReturnDto> PostUser(User user);
        Task<ReturnDto> PutUser(UserRequestDto userRequestDto);
        Task<ReturnDto> PutLastLogOff(UserLastLogOffRequestDto userLastLogOff);
        Task<ReturnDto> DeleteUser(string idUser);
    }
}
