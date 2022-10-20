using API.DarkShame.Domain.Dto.Request.Users;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Users;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;

namespace API.DarkShame.Infra.Repository.Users
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
            var contry = _context.Contry.Find(x => x.ContryId == user.LocationContry).FirstOrDefault();
            if (contry != null)
            {
                var state = _context.State.Find(x => x.StateId == user.LocationState).FirstOrDefault();
                if (state != null)
                {
                    var city = _context.City.Find(x => x.CityId == user.LocationCity).FirstOrDefault();
                    if (city != null)
                    {
                        await _context.Users.InsertOneAsync(user);
                    }
                }
            }
        }

        public async Task PutUser(UserRequestDto userRequestDto)
        {
            var contry = _context.Contry.Find(x => x.ContryId == userRequestDto.LocationContry).FirstOrDefault();
            var state = _context.State.Find(x => x.StateId == userRequestDto.LocationState).FirstOrDefault();
            var city = _context.City.Find(x => x.CityId == userRequestDto.LocationCity).FirstOrDefault();

            var filter = Builders<User>.Filter.Eq(x => x.Id, userRequestDto.Id);
            var update = Builders<User>.Update.Set(x => x.ProfileVisibility, userRequestDto.ProfileVisibility)
                                              .Set(x => x.NickName, userRequestDto.NickName)
                                              .Set(x => x.ProfileUrl, userRequestDto.ProfileUrl)
                                              .Set(x => x.AvatarUrl, userRequestDto.AvatarUrl)
                                              .Set(x => x.Status, userRequestDto.Status)
                                              .Set(x => x.RealName, userRequestDto.RealName)
                                              .Set(x => x.PrimaryGroupId, userRequestDto.PrimaryGroupId)
                                              .Set(x => x.LocationContry, contry.ContryId)
                                              .Set(x => x.LocationState, state.StateId)
                                              .Set(x => x.LocationCity, city.CityId)
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
