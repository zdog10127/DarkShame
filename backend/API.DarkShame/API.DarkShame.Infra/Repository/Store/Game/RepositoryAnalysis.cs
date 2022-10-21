using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Infra.Repository.Store.Game
{
    public class RepositoryAnalysis : IRepositoryAnalysis
    {
        private readonly IContext _context;

        public RepositoryAnalysis()
        {
            _context = new Context();
        }

        public async Task<List<Analysis>> GetAnalysisByIdGame(string idGame)
        {
            var analysis = await _context.Analysis.FindAsync(x => x.IdGame == idGame);
            return analysis.ToList();
        }

        public async Task<List<Analysis>> GetAnalysisByName(string nickName)
        {
            var nick = await _context.Analysis.FindAsync(x => x.NickName == nickName);
            return nick.ToList();
        }

        public async Task<Analysis> GetAnalysisById(string id)
        {
            var analysisId = await _context.Analysis.Find(x => x.Id == id).FirstOrDefaultAsync();
            return analysisId;
        }

        public async Task CreateAnalysis(Analysis analysis)
        {
            var nickName = _context.Users.Find(x => x.NickName == analysis.NickName).FirstOrDefault();
            if (nickName != null)
            {
                await _context.Analysis.InsertOneAsync(analysis);
            }
        }

        public async Task UpdateAnalysis(Analysis analysis, string idGame)
        {
            var filter = Builders<Analysis>.Filter.Eq(x => x.IdGame, idGame);
            var update = Builders<Analysis>.Update.Set(x => x.Note, analysis.Note)
                                                  .Set(x => x.Comment, analysis.Comment)
                                                  .Set(x => x.Evaluation, analysis.Evaluation);

            await _context.Analysis.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAnalysis(string id)
        {
            await _context.Analysis.DeleteOneAsync(id);
        }
    }
}
