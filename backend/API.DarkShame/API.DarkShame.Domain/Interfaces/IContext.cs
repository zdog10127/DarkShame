using API.DarkShame.Domain.Dto.Request.Users;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces
{
    public interface IContext
    {
        //Users
        IMongoCollection<Entities.User> Users { get; }
        IMongoCollection<UserLastLogOffRequestDto> UserLastLogOff { get; }
        
        //Contry - State - City
        IMongoCollection<Entities.Contrys.Contry> Contry { get; }
        IMongoCollection<Entities.Contrys.State> State { get; }
        IMongoCollection<Entities.Contrys.City> City { get; }

        //Groups
        IMongoCollection<Entities.GroupInfo> GroupInfo { get; }

        //Server
        IMongoCollection<Entities.ServerInfo> ServerInfo { get; }
    }
}
