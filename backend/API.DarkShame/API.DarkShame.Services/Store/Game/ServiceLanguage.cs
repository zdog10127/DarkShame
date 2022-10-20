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
    public class ServiceLanguage : IServiceLanguage
    {
        private readonly IRepositoryLanguage _repositoryLanguage;

        public ServiceLanguage()
        {
            _repositoryLanguage = new RepositoryLanguage();
        }

        public async Task<List<Languages>> GetLanguagesByIdGame(string idGame)
        {
            var language = await _repositoryLanguage.GetLanguagesByIdGame(idGame);
            return language;
        }

        public async Task<ReturnDto> CreateLanguages(Languages languages)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryLanguage.CreateLanguages(languages);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar linguagem";
                returnDto.MessageError = "Erro no processo de gravar a linguagem";
            }

            return await Task.FromResult(returnDto);
        }
    }
}
