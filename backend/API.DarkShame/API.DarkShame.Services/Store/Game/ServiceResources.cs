using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Repository.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services.Store.Game
{
    public class ServiceResources : IServiceResources
    {
        private readonly IRepositoryResources _repositoryResources;

        public ServiceResources()
        {
            _repositoryResources = new RepositoryResources();
        }

        public async Task<Resources> GetResourcesByIdGame(string idGame)
        {
            var resources = await _repositoryResources.GetResourcesByIdGame(idGame);
            return resources;
        }

        public async Task<ReturnDto> CreateResources(Resources resources)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryResources.CreateResources(resources);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Recursos";
                returnDto.MessageError = "Erro no processo de gravar Recursos";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> UpdateResources(Resources resources, string idGame)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryResources.UpdateResources(resources, idGame);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Recursos";
                returnDto.MessageError = "Erro no processo de gravar Recursos";
            }

            return await Task.FromResult(returnDto);
        }
    }
}
