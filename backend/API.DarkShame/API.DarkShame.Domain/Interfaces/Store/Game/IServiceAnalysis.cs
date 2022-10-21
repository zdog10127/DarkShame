using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Store.Game
{
    public interface IServiceAnalysis
    {
        Task<List<Analysis>> GetAnalysisByIdGame(string idGame);
        Task<List<Analysis>> GetAnalysisByName(string nickName);
        Task<Analysis> GetAnalysisById(string id);
        Task<ReturnDto> CreateAnalysis(Analysis analysis);
        Task<ReturnDto> UpdateAnalysis(Analysis analysis, string idGame);
        Task<ReturnDto> DeleteAnalysis(string id);
    }
}
