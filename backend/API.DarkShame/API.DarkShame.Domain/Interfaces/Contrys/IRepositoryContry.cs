using API.DarkShame.Domain.Entities.Contrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Contrys
{
    public interface IRepositoryContry
    {
        Task<List<Contry>> GetContry();
        Task<Contry> GetContryById(int idContry);
        Task PostContry(List<Contry> contry);
    }
}
