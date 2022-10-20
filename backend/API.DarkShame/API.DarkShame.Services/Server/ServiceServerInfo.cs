using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Interfaces.Server;
using API.DarkShame.Infra.Repository.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services.Server
{
    public class ServiceServerInfo : IServiceServerInfo
    {
        private readonly IRepositoryServerInfo _repositoryServerInfo;

        public ServiceServerInfo()
        {
            _repositoryServerInfo = new RepositoryServerInfo();
        }

        public async Task<ServerInfo> ServerStatus()
        {
            var serverInfo = await _repositoryServerInfo.ServerStatus();
            return serverInfo;
        }

        public async Task<ReturnDto> CreateStatusServer(ServerInfo serverInfo)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryServerInfo.CreateStatusServer(serverInfo);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Servidor";
                returnDto.MessageError = "Erro no processo de gravar o Servidor";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> UpdateStatusServer(ServerInfo serverInfo)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryServerInfo.UpdateStatusServer(serverInfo);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Atualizar o Servidor";
                returnDto.MessageError = "Erro no processo de atualizar o Servidor";
            }

            return await Task.FromResult(returnDto);
        }
    }
}
