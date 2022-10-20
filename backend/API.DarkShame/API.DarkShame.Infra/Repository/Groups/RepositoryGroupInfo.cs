using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DarkShame.Domain.Dto.Request;
using API.DarkShame.Domain.Dto.Request.Groups;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Groups;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;

namespace API.DarkShame.Infra.Repository.Groups
{
    public class RepositoryGroupInfo : IRepositoryGroupInfo
    {
        private readonly IContext _context;

        public RepositoryGroupInfo()
        {
            _context = new Context();
        }

        public async Task<List<GroupInfo>> GetGroup()
        {
            var groups = await _context.GroupInfo.FindAsync(_ => true);
            return groups.ToList();
        }

        public async Task<GroupInfo> GroupId(string idGroup)
        {
            var group = await _context.GroupInfo.Find(x => x.Id == idGroup).FirstOrDefaultAsync();
            return group;
        }

        public async Task CreateGroup(GroupInfo groupInfo)
        {
            var contry = _context.Contry.Find(x => x.ContryId == groupInfo.LocationCity).FirstOrDefault();
            if (contry != null)
            {
                var state = _context.State.Find(x => x.StateId == groupInfo.LocationState).FirstOrDefault();
                if (state != null)
                {
                    var city = _context.City.Find(x => x.CityId == groupInfo.LocationCity).FirstOrDefault();
                    if (city != null)
                    {
                        var user = _context.Users.Find(x => x.NickName == groupInfo.Owner).FirstOrDefault();
                        if (user != null)
                        {
                            await _context.GroupInfo.InsertOneAsync(groupInfo);
                        }
                    }
                }
            }
        }

        public async Task UpdateGroup(GroupInfoRequestDto groupInfoRequestDto)
        {
            var contry = _context.Contry.Find(x => x.ContryId == groupInfoRequestDto.LocationContry).FirstOrDefault();
            var state = _context.State.Find(x => x.StateId == groupInfoRequestDto.LocationState).FirstOrDefault();
            var city = _context.City.Find(x => x.CityId == groupInfoRequestDto.LocationCity).FirstOrDefault();

            var filter = Builders<GroupInfo>.Filter.Eq(x => x.Id, groupInfoRequestDto.Id);
            var update = Builders<GroupInfo>.Update.Set(x => x.Name, groupInfoRequestDto.Name)
                                                   .Set(x => x.HeadLine, groupInfoRequestDto.HeadLine)
                                                   .Set(x => x.Summary, groupInfoRequestDto.Summary)
                                                   .Set(x => x.Abbreviation, groupInfoRequestDto.Abbreviation)
                                                   .Set(x => x.ProfileUrl, groupInfoRequestDto.ProfileUrl)
                                                   .Set(x => x.AvatarUrl, groupInfoRequestDto.AvatarUrl)
                                                   .Set(x => x.LocationContry, contry.ContryId)
                                                   .Set(x => x.LocationState, state.StateId)
                                                   .Set(x => x.LocationCity, city.CityId)
                                                   .Set(x => x.FavoriteAppId, groupInfoRequestDto.FavoriteAppId)
                                                   .Set(x => x.Members, groupInfoRequestDto.Members)
                                                   .Set(x => x.UsersOnline, groupInfoRequestDto.UsersOnline)
                                                   .Set(x => x.UsersInChat, groupInfoRequestDto.UsersInChat)
                                                   .Set(x => x.UsersInGame, groupInfoRequestDto.UsersInGame)
                                                   .Set(x => x.Owner, groupInfoRequestDto.Owner);
            
            await _context.GroupInfo.UpdateOneAsync(filter, update);
        }

        public async Task DeleteGroup(string idGroup)
        {
            await _context.GroupInfo.DeleteOneAsync(x => x.Id == idGroup);
        }
    }
}