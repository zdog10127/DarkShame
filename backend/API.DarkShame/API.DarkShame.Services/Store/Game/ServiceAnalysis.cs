using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Repository.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services.Store.Game
{
    public class ServiceAnalysis : IServiceAnalysis
    {
        private readonly IRepositoryAnalysis _repositoryAnalysis;

        public ServiceAnalysis()
        {
            _repositoryAnalysis = new RepositoryAnalysis();
        }

        public async Task<List<Analysis>> GetAnalysisByIdGame(string idGame)
        {
            var analysis = await _repositoryAnalysis.GetAnalysisByIdGame(idGame);
            return analysis;
        }

        public async Task<List<Analysis>> GetAnalysisByName(string nickName)
        {
            var nick = await _repositoryAnalysis.GetAnalysisByName(nickName);
            return nick;
        }

        public async Task<Analysis> GetAnalysisById(string id)
        {
            var analysisId = await _repositoryAnalysis.GetAnalysisById(id);
            return analysisId;
        }

        public async Task<ReturnDto> CreateAnalysis(Analysis analysis)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryAnalysis.CreateAnalysis(analysis);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Analise";
                returnDto.MessageError = "Erro no processo de gravar Analise";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> UpdateAnalysis(Analysis analysis, string idGame)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryAnalysis.UpdateAnalysis(analysis, idGame);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Atualizar Analise";
                returnDto.MessageError = "Erro no processo de atualizar Analise";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> DeleteAnalysis(string id)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryAnalysis.DeleteAnalysis(id);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Deletar Analise";
                returnDto.MessageError = "Erro no processo de deletar Analise";
            }

            return await Task.FromResult(returnDto);
        }
    }
}
