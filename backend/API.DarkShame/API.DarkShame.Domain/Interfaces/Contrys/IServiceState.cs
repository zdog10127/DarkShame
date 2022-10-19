using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Contrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Contrys
{
    public interface IServiceState
    {
        Task<List<State>> GetState();
        Task<State> GetStateById(int idState);
        Task<ReturnDto> PostState(List<State> state);
    }
}
