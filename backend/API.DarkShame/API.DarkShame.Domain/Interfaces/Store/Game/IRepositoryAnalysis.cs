using API.DarkShame.Domain.Entities.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Store.Game
{
    public interface IRepositoryAnalysis
    {
        Task<List<Analysis>> GetAnalysisByIdGame(string idGame);
        Task<List<Analysis>> GetAnalysisByName(string nickName);
        Task<Analysis> GetAnalysisById(string id);
        Task CreateAnalysis(Analysis analysis);
        Task UpdateAnalysis(Analysis analysis, string idGame);
        Task DeleteAnalysis(string id);
    }
}
