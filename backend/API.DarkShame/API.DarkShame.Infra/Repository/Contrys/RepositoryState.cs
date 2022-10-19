using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Contrys;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;

namespace API.DarkShame.Infra.Repository.Contrys
{
    public class RepositoryState : IRepositoryState
    {
        private readonly IContext _context;

        public RepositoryState()
        {
            _context = new Context();
        }

        public async Task<List<State>> GetState()
        {
            var state = await _context.State.FindAsync(_ => true);
            return state.ToList();
        }

        public async Task<State> GetStateById(int idState)
        {
            var stateId = await _context.State.Find(x => x.StateId == idState).FirstOrDefaultAsync();
            return stateId;
        }

        public async Task PostState(State state)
        {
            var contry = _context.Contry.Find(x => x.ContryId == state.ContryId).FirstOrDefault();
            if (contry != null)
            {
                await _context.State.InsertOneAsync(state);
            }
        }
    }
}
