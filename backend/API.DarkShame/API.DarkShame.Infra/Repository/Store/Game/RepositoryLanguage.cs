using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;

namespace API.DarkShame.Infra.Repository.Store.Game
{
    public class RepositoryLanguage : IRepositoryLanguage
    {
        private readonly IContext _context;

        public RepositoryLanguage()
        {
            _context = new Context();
        }

        public async Task<List<Languages>> GetLanguagesByIdGame(string idGame)
        {
            var languages = await _context.Languages.FindAsync(x => x.IdGame == idGame);
            return languages.ToList();
        }

        public async Task CreateLanguages(Languages languages)
        {
            await _context.Languages.InsertOneAsync(languages);
        }
    }
}
