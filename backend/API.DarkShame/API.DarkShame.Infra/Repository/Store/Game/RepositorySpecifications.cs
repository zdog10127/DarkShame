using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;

namespace API.DarkShame.Infra.Repository.Store.Game
{
    public class RepositorySpecifications : IRepositorySpecifications
    {
        private readonly IContext _context;

        public RepositorySpecifications()
        {
            _context = new Context();
        }

        //Specifications Minimum
        public async Task<SpecificationsMinimum> GetSpecificationsMinimum(string idGame)
        {
            var specificationsMin = await _context.SpecificationsMinimum.Find(x => x.IdGame == idGame).FirstOrDefaultAsync();
            return specificationsMin;
        }

        public async Task CreateSpecificationsMinimum(SpecificationsMinimum specificationsMinimum)
        {
            await _context.SpecificationsMinimum.InsertOneAsync(specificationsMinimum);
        }

        //Specifications Maximum
        public async Task<SpecificationsMaximum> GetSpecificationsMaximum(string idGame)
        {
            var specificationsMax = await _context.SpecificationsMaximum.Find(x => x.IdGame == idGame).FirstOrDefaultAsync();
            return specificationsMax;
        }

        public async Task CreateSpecificationsMaximum(SpecificationsMaximum specificationsMaximum)
        {
            await _context.SpecificationsMaximum.InsertOneAsync(specificationsMaximum);
        }

    }
}
