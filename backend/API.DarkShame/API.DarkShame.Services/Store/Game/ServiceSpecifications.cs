using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Repository.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services.Store.Game
{
    public class ServiceSpecifications : IServiceSpecifications
    {
        private readonly IRepositorySpecifications _repositorySpecifications;

        public ServiceSpecifications()
        {
            _repositorySpecifications = new RepositorySpecifications();
        }

        //Specifications Minimum
        public async Task<SpecificationsMinimum> GetSpecificationsMinimum(string idGame)
        {
            var specificationsMinimum = await _repositorySpecifications.GetSpecificationsMinimum(idGame);
            return specificationsMinimum;
        }

        public async Task<ReturnDto> CreateSpecificationsMinimum(SpecificationsMinimum specificationsMinimum)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositorySpecifications.CreateSpecificationsMinimum(specificationsMinimum);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Especificação Minima";
                returnDto.MessageError = "Erro no processo de gravar Especificação Minima";
            }

            return await Task.FromResult(returnDto);
        }

        //Specifications Maximum
        public Task<SpecificationsMaximum> GetSpecificationsMaximum(string idGame)
        {
            var specificationMaximum = _repositorySpecifications.GetSpecificationsMaximum(idGame);
            return specificationMaximum;
        }

        public async Task<ReturnDto> CreateSpecificationsMaximum(SpecificationsMaximum specificationsMaximum)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositorySpecifications.CreateSpecificationsMaximum(specificationsMaximum);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Especificação Maxima";
                returnDto.MessageError = "Erro no processo de gravar Especificação Maxima";
            }

            return await Task.FromResult(returnDto);
        }
    }
}
