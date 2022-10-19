using API.DarkShame.Domain.Dto.Request;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Infra.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            /*var options = new AggregateOptions()
            {
                AllowDiskUse = true
            };

            PipelineDefinition<User, BsonDocument> pipeline1 = new BsonDocument[]
            {
                new BsonDocument("$project", new BsonDocument()
                        .Add("_id", 0)
                        .Add("users", "$$ROOT")),
                new BsonDocument("$lookup", new BsonDocument()
                        .Add("localField", "users.locationContry")
                        .Add("from", "contry")
                        .Add("foreignField", "contryId")
                        .Add("as", "contry")),

                new BsonDocument("$unwind", new BsonDocument()
                        .Add("path", "$contry")
                        .Add("preserveNullAndEmptyArrays", new BsonBoolean(false))),
                new BsonDocument("$project", new BsonDocument()
                        .Add("users._id", "$users._id")
                        .Add("users.profileVisibility", "$users.profileVisibility")
                        .Add("users.profileState", "$users.profileState")
                        .Add("users.nickName", "$users.nickName")
                        //.Add("users.lastLogoff", "$users.lastLogoff")
                        .Add("users.profileUrl", "$users.profileUrl")
                        .Add("users.avatarUrl", "$users.avatarUrl")
                        .Add("users.status", "$users.status")
                        .Add("users.realName", "$users.realName")
                        .Add("users.primaryGroupId", "$users.primaryGroupId")
                        //.Add("users.joinDate", "$users.joinDate")
                        .Add("users.locationContry", "$users.locationContry")
                        .Add("users.locationContryName", "$contry.nameContry")
                        .Add("users.locationState", "$users.locationState")
                        .Add("users.locationStateName", "$state.nameState")
                        .Add("users.locationCity", "$users.locationCity")
                        .Add("users.locationCityName", "$city.nameCity")
                        .Add("users.summary", "$users.summary")
                        .Add("_id", 0)),
            };

            PipelineDefinition<User, BsonDocument> pipeline2 = new BsonDocument[]{
                new BsonDocument("$project", new BsonDocument()
                        .Add("_id", 0)
                        .Add("users", "$$ROOT")),
                new BsonDocument("$lookup", new BsonDocument()
                        .Add("localField", "users.locationState")
                        .Add("from", "state")
                        .Add("foreignField", "stateId")
                        .Add("as", "state")),
                new BsonDocument("$unwind", new BsonDocument()
                        .Add("path", "$state")
                        .Add("preserveNullAndEmptyArrays", new BsonBoolean(false))),
                new BsonDocument("$project", new BsonDocument()
                        .Add("users._id", "$users._id")
                        .Add("users.profileVisibility", "$users.profileVisibility")
                        .Add("users.profileState", "$users.profileState")
                        .Add("users.nickName", "$users.nickName")
                        //.Add("users.lastLogoff", "$users.lastLogoff")
                        .Add("users.profileUrl", "$users.profileUrl")
                        .Add("users.avatarUrl", "$users.avatarUrl")
                        .Add("users.status", "$users.status")
                        .Add("users.realName", "$users.realName")
                        .Add("users.primaryGroupId", "$users.primaryGroupId")
                        //.Add("users.joinDate", "$users.joinDate")
                        .Add("users.locationContry", "$users.locationContry")
                        .Add("users.locationContryName", "$contry.nameContry")
                        .Add("users.locationState", "$users.locationState")
                        .Add("users.locationStateName", "$state.nameState")
                        .Add("users.locationCity", "$users.locationCity")
                        .Add("users.locationCityName", "$city.nameCity")
                        .Add("users.summary", "$users.summary")
                        .Add("_id", 0)),
            };

            PipelineDefinition<User, BsonDocument> pipeline3 = new BsonDocument[]{
                new BsonDocument("$project", new BsonDocument()
                        .Add("_id", 0)
                        .Add("users", "$$ROOT")),
                new BsonDocument("$lookup", new BsonDocument()
                        .Add("localField", "users.locationCity")
                        .Add("from", "city")
                        .Add("foreignField", "cityId")
                        .Add("as", "city")),
                new BsonDocument("$unwind", new BsonDocument()
                        .Add("path", "city")
                        .Add("preserveNullAndEmptyArrays", new BsonBoolean(false))),
                new BsonDocument("$project", new BsonDocument()
                        .Add("users._id", "$users._id")
                        .Add("users.profileVisibility", "$users.profileVisibility")
                        .Add("users.profileState", "$users.profileState")
                        .Add("users.nickName", "$users.nickName")
                        //.Add("users.lastLogoff", "$users.lastLogoff")
                        .Add("users.profileUrl", "$users.profileUrl")
                        .Add("users.avatarUrl", "$users.avatarUrl")
                        .Add("users.status", "$users.status")
                        .Add("users.realName", "$users.realName")
                        .Add("users.primaryGroupId", "$users.primaryGroupId")
                        //.Add("users.joinDate", "$users.joinDate")
                        .Add("users.locationContry", "$users.locationContry")
                        .Add("users.locationContryName", "$contry.nameContry")
                        .Add("users.locationState", "$users.locationState")
                        .Add("users.locationStateName", "$state.nameState")
                        .Add("users.locationCity", "$users.locationCity")
                        .Add("users.locationCityName", "$city.nameCity")
                        .Add("users.summary", "$users.summary")
                        .Add("_id", 0)),
            };

            var pipeline = (pipeline1, pipeline2, pipeline3);
                 
            List<User> lstUsers = new List<User>();

            using (var cursor = await _context.Users.AggregateAsync(pipeline, options))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (BsonDocument document in batch)
                    {
                        JObject jObject = JObject.Parse(document.ToJson().Replace("_id", "id").Replace("ObjectId(", "").Replace(")", ""));
                        var users = jObject["users"].ToString();
                        var add = JsonConvert.DeserializeObject<User>(users);
                        lstUsers.Add(add);
                    }
                }
            }

            return lstUsers;*/
        }

        public async Task<User> GetUserId(string idUser)
        {
            var users = await _context.Users.Find(x => x.Id == idUser).FirstOrDefaultAsync();
            return users;
        }

        public async Task PostUser(User user)
        {
            var contry = _context.Contry.Find(x => x.ContryId == user.locationContry).FirstOrDefault();
            if (contry != null)
            {
                var state = _context.State.Find(x => x.StateId == user.locationState).FirstOrDefault();
                if (state != null)
                {
                    var city = _context.City.Find(x => x.CityId == user.locationCity).FirstOrDefault();
                    if (city != null)
                    {
                        await _context.Users.InsertOneAsync(user);
                    }
                }
            }
        }

        public async Task PutUser(UserRequestDto userRequestDto)
        {
            var contry = _context.Contry.Find(x => x.ContryId == userRequestDto.locationContry).FirstOrDefault();
            var state = _context.State.Find(x => x.StateId == userRequestDto.locationState).FirstOrDefault();
            var city = _context.City.Find(x => x.CityId == userRequestDto.locationCity).FirstOrDefault();

            var filter = Builders<User>.Filter.Eq(x => x.Id, userRequestDto.Id);
            var update = Builders<User>.Update.Set(x => x.ProfileVisibility, userRequestDto.ProfileVisibility)
                                              .Set(x => x.NickName, userRequestDto.NickName)
                                              .Set(x => x.ProfileUrl, userRequestDto.ProfileUrl)
                                              .Set(x => x.AvatarUrl, userRequestDto.AvatarUrl)
                                              .Set(x => x.Status, userRequestDto.Status)
                                              .Set(x => x.RealName, userRequestDto.RealName)
                                              .Set(x => x.PrimaryGroupId, userRequestDto.PrimaryGroupId)
                                              .Set(x => x.locationContry, contry.ContryId)
                                              .Set(x => x.locationState, state.StateId)
                                              .Set(x => x.locationCity, city.CityId)
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
