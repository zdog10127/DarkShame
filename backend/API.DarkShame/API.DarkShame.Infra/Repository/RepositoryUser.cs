using API.DarkShame.Domain.Dto.Request;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Infra.Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly IContext _context;

        public RepositoryUser()
        {
            _context = new Context();
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _context.Users.FindAsync(_ => true);
            return users.ToList();
        }

        public async Task<User> GetUserId(string idUser)
        {
            var users = await _context.Users.Find(x => x.Id == idUser).FirstOrDefaultAsync();
            return users;
        }

        public async Task PostUser(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task PutUser(UserRequestDto userRequestDto)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, userRequestDto.Id);
            var update = Builders<User>.Update.Set(x => x.ProfileVisibility, userRequestDto.ProfileVisibility)
                                              .Set(x => x.NickName, userRequestDto.NickName)
                                              .Set(x => x.ProfileUrl, userRequestDto.ProfileUrl)
                                              .Set(x => x.AvatarUrl, userRequestDto.AvatarUrl)
                                              .Set(x => x.Status, userRequestDto.Status)
                                              .Set(x => x.RealName, userRequestDto.RealName)
                                              .Set(x => x.PrimaryGroupId, userRequestDto.PrimaryGroupId)
                                              .Set(x => x.locationContry, userRequestDto.locationContry)
                                              .Set(x => x.locationState, userRequestDto.locationState)
                                              .Set(x => x.locationCity, userRequestDto.locationCity)
                                              .Set(x => x.Summary, userRequestDto.Summary);

            await _context.Users.UpdateOneAsync(filter, update);
        }

        public async Task PutLastLogOff(UserLastLogOffRequestDto userLastLogOff)
        {
            var filter = Builders<UserLastLogOffRequestDto>.Filter.Eq(x => x.Id, userLastLogOff.Id);
            var update = Builders<UserLastLogOffRequestDto>.Update.Set(x => x.LastLogoff, userLastLogOff.LastLogoff);

            await _context.UserLastLogOff.UpdateOneAsync(filter, update);
        }

        public async Task DeleteUser(string idUser)
        {
            await _context.Users.DeleteOneAsync(x => x.Id == idUser);
        }
    }
}
