using API.DarkShame.Domain.Entities.Contrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Contrys
{
    public interface IRepositoryState
    {
        Task<List<State>> GetState();
        Task<State> GetStateById(int idState);
        Task PostState(List<State> state);
    }
}
