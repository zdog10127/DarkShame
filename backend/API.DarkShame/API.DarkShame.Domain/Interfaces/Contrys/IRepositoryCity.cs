using API.DarkShame.Domain.Entities.Contrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Contrys
{
    public interface IRepositoryCity
    {
        Task<List<City>> GetCity();
        Task<City> GetCityById(int idCity);
        Task PostCity(List<City> City);
    }
}
