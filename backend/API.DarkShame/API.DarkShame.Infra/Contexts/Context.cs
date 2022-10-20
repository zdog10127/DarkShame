using API.DarkShame.Domain.Dto.Request.Store.Game;
using API.DarkShame.Domain.Dto.Request.Users;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Utility;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Infra.Contexts
{
    public class Context : IContext
    {
        //Users
        public IMongoCollection<User> Users { get; }
        public IMongoCollection<UserLastLogOffRequestDto> UserLastLogOff { get; }

        //Contry - State - City
        public IMongoCollection<Contry> Contry { get; }
        public IMongoCollection<State> State { get; }
        public IMongoCollection<City> City { get; }

        //Group
        public IMongoCollection<GroupInfo> GroupInfo { get; }

        //Server
        public IMongoCollection<ServerInfo> ServerInfo { get; }

        //Games
        public IMongoCollection<Games> Games { get; }
        public IMongoCollection<GamesRequestDto> GamesDto { get; }
        public IMongoCollection<Analysis> Analysis { get; }
        public IMongoCollection<Languages> Languages { get; }
        public IMongoCollection<Resources> Resources { get; }
        public IMongoCollection<SpecificationsMinimum> SpecificationsMinimum { get; }
        public IMongoCollection<SpecificationsMaximum> SpecificationsMaximum { get; }

        public Context()
        {
            var client = new MongoClient(ApplicationSettings.GetStringMongoConnection());
            var dataBase = client.GetDatabase("darkshame");
            
            //Users
            Users = dataBase.GetCollection<User>("users");
            UserLastLogOff = dataBase.GetCollection<UserLastLogOffRequestDto>("users");

            //Contry - State - City
            Contry = dataBase.GetCollection<Contry>("contry");
            State = dataBase.GetCollection<State>("state");
            City = dataBase.GetCollection<City>("city");

            //Group
            GroupInfo = dataBase.GetCollection<GroupInfo>("groups");

            //Server
            ServerInfo = dataBase.GetCollection<ServerInfo>("server");

            //Games
            Games = dataBase.GetCollection<Games>("games");
            GamesDto = dataBase.GetCollection<GamesRequestDto>("games");
            Analysis = dataBase.GetCollection<Analysis>("analysis");
            Languages = dataBase.GetCollection<Languages>("languages");
            Resources = dataBase.GetCollection<Resources>("resources");
            SpecificationsMinimum = dataBase.GetCollection<SpecificationsMinimum>("specificationsMinimum");
            SpecificationsMaximum = dataBase.GetCollection<SpecificationsMaximum>("specificationsMaximum");
        }
    }
}
