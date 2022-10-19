using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Contrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Contrys
{
    public interface IServiceContry
    {
        Task<List<Contry>> GetContry();
        Task<Contry> GetContryById(int idContry);
        Task<ReturnDto> PostContry(List<Contry> contry);
    }
}
