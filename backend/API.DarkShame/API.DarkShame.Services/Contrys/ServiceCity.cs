using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Contrys;
using API.DarkShame.Domain.Interfaces.Contrys;
using API.DarkShame.Infra.Repository.Contrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services.Contrys
{
    public class ServiceCity : IServiceCity
    {
        private readonly IRepositoryCity _repositoryCity;

        public ServiceCity()
        {
            _repositoryCity = new RepositoryCity();
        }

        public async Task<List<City>> GetCity()
        {
            var citys = await _repositoryCity.GetCity();
            return citys;
        }

        public async Task<City> GetCityById(int idCity)
        {
            var cityId = await _repositoryCity.GetCityById(idCity);
            return cityId;
        }

        public async Task<ReturnDto> PostCity(List<City> city)
        {
            ReturnDto returnDto = new ReturnDto();

            foreach (var cityItem in city)
            {
                var result = GetCityById(cityItem.CityId);

                if (result.Result == null)
                {
                    var ret = _repositoryCity.PostCity(cityItem);

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
                    returnDto.MessageError = $"Já existe uma cobertura cadastrada para o código {cityItem.CityId}.";
                }
            }

            return await Task.FromResult(returnDto);
        }
    }
}
