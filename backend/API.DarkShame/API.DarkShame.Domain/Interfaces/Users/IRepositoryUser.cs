using API.DarkShame.Domain.Dto.Request.Users;
using API.DarkShame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Users
{
    public interface IRepositoryUser
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserId(string idUser);
        Task PostUser(User user);
        Task PutUser(UserRequestDto userRequestDto);
        Task PutLastLogOff(UserLastLogOffRequestDto userLastLogOff);
        Task DeleteUser(string idUser);
    }
}
