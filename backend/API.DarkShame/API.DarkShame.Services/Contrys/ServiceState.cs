using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Interfaces.Contrys;
using API.DarkShame.Infra.Repository.Contrys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services.Contrys
{
    public class ServiceState : IServiceState
    {
        private readonly IRepositoryState _repositoryState;

        public ServiceState()
        {
            _repositoryState = new RepositoryState();
        }

        public async Task<List<State>> GetState()
        {
            var states = await _repositoryState.GetState();
            return states;
        }

        public async Task<State> GetStateById(int idState)
        {
            var stateId = await _repositoryState.GetStateById(idState);
            return stateId;
        }

        public async Task<ReturnDto> PostState(List<State> state)
        {
            ReturnDto returnDto = new ReturnDto();

            foreach (var stateItem in state)
            {
                var result = GetStateById(stateItem.StateId);

                if(result.Result == null)
                {
                    var ret = _repositoryState.PostState(stateItem);

                    if (ret.Exception != null)
                    {
                        returnDto.ThereError = true;
                        returnDto.CodeError = "400";
                        returnDto.TitleError = "Gravar Estado";
                        returnDto.MessageError = "Erro no processo de gravar Estado";
                    }
                } 
                else
                {
                    returnDto.ThereError = true;
                    returnDto.CodeError = "400";
                    returnDto.TitleError = "Registro Duplicados";
                    returnDto.MessageError = $"Já existe uma cobertura cadastrada para o código {stateItem.StateId}.";
                }
            }
            
            return await Task.FromResult(returnDto);
        }
    }
}
