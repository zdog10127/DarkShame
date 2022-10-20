using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;

namespace API.DarkShame.Infra.Repository.Store.Game
{
    public class RepositoryResources : IRepositoryResources
    {
        private readonly IContext _context;

        public RepositoryResources()
        {
            _context = new Context();
        }

        public async Task<Resources> GetResourcesByIdGame(string idGame)
        {
            var resources = await _context.Resources.Find(x => x.IdGame == idGame).FirstOrDefaultAsync();
            return resources;
        }

        public async Task CreateResources(Resources resources)
        {
            await _context.Resources.InsertOneAsync(resources);
        }

        public async Task UpdateResources(Resources resources, string idGame)
        {
            var filter = Builders<Resources>.Filter.Eq(x => x.IdGame, idGame);
            var update = Builders<Resources>.Update.Set(x => x.OnePlayer, resources.OnePlayer)
                                                   .Set(x => x.Cooperative, resources.Cooperative)
                                                   .Set(x => x.Achievements, resources.Achievements)
                                                   .Set(x => x.CollectibleCards, resources.CollectibleCards)
                                                   .Set(x => x.ControllerCompatible, resources.ControllerCompatible)
                                                   .Set(x => x.Cloud, resources.Cloud);

            await _context.Resources.UpdateOneAsync(filter, update);
        }
    }
}
