using API.DarkShame.Domain.Entities;

namespace API.DarkShame.Domain.Interfaces.Server
{
    public interface IRepositoryServerInfo
    {
        Task<ServerInfo> ServerStatus();
        Task CreateStatusServer(ServerInfo serverInfo);
        Task UpdateStatusServer(ServerInfo serverInfo);
    }
}
