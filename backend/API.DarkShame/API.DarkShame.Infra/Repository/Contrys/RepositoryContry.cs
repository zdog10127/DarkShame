using API.DarkShame.Domain.Entities;
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
    public class RepositoryContry : IRepositoryContry
    {
        private readonly IContext _context;

        public RepositoryContry()
        {
            _context = new Context();
        }

        public async Task<List<Contry>> GetContry()
        {
            var contrys = await _context.Contry.FindAsync(_ => true);
            return contrys.ToList();
        }

        public async Task<Contry> GetContryById(int idContry)
        {
            var contryId = await _context.Contry.Find(x => x.ContryId == idContry).FirstOrDefaultAsync();
            return contryId;
        }

        public async Task PostContry(List<Contry> contry)
        {
            await _context.Contry.InsertManyAsync(contry);
        }
    }
}
