using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Contrys;
using API.DarkShame.Infra.Repository;
using API.DarkShame.Infra.Repository.Contrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services.Contrys
{
    public class ServiceContry : IServiceContry
    {
        private readonly IRepositoryContry _repositoryContry;

        public ServiceContry()
        {
            _repositoryContry = new RepositoryContry();
        }

        public async Task<List<Contry>> GetContry()
        {
            var contrys = await _repositoryContry.GetContry();
            return contrys;
        }

        public async Task<Contry> GetContryById(int idContry)
        {
            var contryId = await _repositoryContry.GetContryById(idContry);
            return contryId;
        }

        public async Task<ReturnDto> PostContry(List<Contry> contry)
        {
            ReturnDto returnDto = new ReturnDto();

            foreach (var contryItem in contry)
            {
                var result = GetContryById(contryItem.ContryId);

                if (result.Result == null)
                {
                    var ret = _repositoryContry.PostContry(contryItem);

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
                    returnDto.MessageError = $"Já existe uma cobertura cadastrada para o código {contryItem.ContryId}.";
                }
            }

            return await Task.FromResult(returnDto);
        }
    }
}
