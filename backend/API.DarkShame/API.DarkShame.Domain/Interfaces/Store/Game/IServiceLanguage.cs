using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Store.Game
{
    public interface IServiceLanguage
    {
        Task<List<Languages>> GetLanguagesByIdGame(string idGame);
        Task<ReturnDto> CreateLanguages(Languages languages);
    }
}
