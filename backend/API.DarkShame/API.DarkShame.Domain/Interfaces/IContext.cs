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
        IMongoCollection<Dto.Request.Users.UserLastLogOffRequestDto> UserLastLogOff { get; }
        
        //Contry - State - City
        IMongoCollection<Entities.Contrys.Contry> Contry { get; }
        IMongoCollection<Entities.Contrys.State> State { get; }
        IMongoCollection<Entities.Contrys.City> City { get; }

        //Groups
        IMongoCollection<Entities.GroupInfo> GroupInfo { get; }

        //Server
        IMongoCollection<Entities.ServerInfo> ServerInfo { get; }

        //Games
        IMongoCollection<Entities.Store.Game.Games> Games { get; }
        IMongoCollection<Dto.Request.Store.Game.GamesRequestDto> GamesDto { get; }
        IMongoCollection<Entities.Store.Game.Analysis> Analysis { get; }
        IMongoCollection<Entities.Store.Game.Languages> Languages { get; }
        IMongoCollection<Entities.Store.Game.Resources> Resources { get; }
        IMongoCollection<Entities.Store.Game.SpecificationsMinimum> SpecificationsMinimum { get; }
        IMongoCollection<Entities.Store.Game.SpecificationsMaximum> SpecificationsMaximum { get; }

        //Payments
        IMongoCollection<Entities.Store.Payment.Payments> Payments { get; }

    }
}
