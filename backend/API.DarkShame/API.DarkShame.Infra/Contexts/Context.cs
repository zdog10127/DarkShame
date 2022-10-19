using API.DarkShame.Domain.Dto.Request;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Entities.Contrys;
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
        }
    }
}
