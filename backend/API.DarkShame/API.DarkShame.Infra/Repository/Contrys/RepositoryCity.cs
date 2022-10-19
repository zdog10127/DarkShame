using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Contrys;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Infra.Repository.Contrys
{
    public class RepositoryCity : IRepositoryCity
    {
        private readonly IContext _context;

        public RepositoryCity()
        {
            _context = new Context();
        }

        public async Task<List<City>> GetCity()
        {
            var city = await _context.City.FindAsync(_ => true);
            return city.ToList();
        }

        public async Task<City> GetCityById(int idCity)
        {
            var cityId = await _context.City.Find(x => x.CityId == idCity).FirstOrDefaultAsync();
            return cityId;
        }

        public async Task PostCity(City city)
        {
            var contry = _context.State.Find(x => x.StateId == city.StateId).FirstOrDefault();
            if (contry != null)
            {
                await _context.City.InsertOneAsync(city);
            }
        }
    }
}
