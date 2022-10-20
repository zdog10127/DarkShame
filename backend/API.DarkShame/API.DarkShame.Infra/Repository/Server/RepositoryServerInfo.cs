using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Server;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Infra.Repository.Server
{
    public class RepositoryServerInfo : IRepositoryServerInfo
    {
        private readonly IContext _context;

        public RepositoryServerInfo()
        {
            _context = new Context();
        }

        public async Task<ServerInfo> ServerStatus()
        {
            var serverInfo = await _context.ServerInfo.Find(_ => true).FirstOrDefaultAsync();
            return serverInfo;
        }

        public async Task CreateStatusServer(ServerInfo serverInfo)
        {
            await _context.ServerInfo.InsertOneAsync(serverInfo);
        }

        public async Task UpdateStatusServer(ServerInfo serverInfo)
        {
            var filter = Builders<ServerInfo>.Filter.Eq(x => x.Id, serverInfo.Id);
            var update = Builders<ServerInfo>.Update.Set(x => x.ServerTime, serverInfo.ServerTime)
                                                    .Set(x => x.ServerTimeString, serverInfo.ServerTimeString);

            await _context.ServerInfo.UpdateOneAsync(filter, update);
        }
    }
}
