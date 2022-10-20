using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities;

namespace API.DarkShame.Domain.Interfaces.Server
{
    public interface IServiceServerInfo
    {
        Task<ServerInfo> ServerStatus();
        Task<ReturnDto> CreateStatusServer(ServerInfo serverInfo);
        Task<ReturnDto> UpdateStatusServer(ServerInfo serverInfo);
    }
}
