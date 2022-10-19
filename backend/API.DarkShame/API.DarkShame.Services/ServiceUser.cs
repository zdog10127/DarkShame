using API.DarkShame.Domain.Dto.Request;
using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;

        public ServiceUser()
        {
            _repositoryUser = new RepositoryUser();
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _repositoryUser.GetUsers();
            return users;
        }

        public async Task<User> GetUserId(string idUser)
        {
            var userId = await _repositoryUser.GetUserId(idUser);
            return userId;
        }

        public async Task<ReturnDto> PostUser(User user)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryUser.PostUser(user);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Usuario";
                returnDto.MessageError = "Erro no processo de gravar Usuário";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> PutUser(UserRequestDto userRequestDto)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryUser.PutUser(userRequestDto);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Atualizar Usuario";
                returnDto.MessageError = "Erro no processo de atualizar o Usuário";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> PutLastLogOff(UserLastLogOffRequestDto userLastLogOff)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryUser.PutLastLogOff(userLastLogOff);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Atualizar Usuario";
                returnDto.MessageError = "Erro no processo de atualizar o Usuário";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> DeleteUser(string idUser)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryUser.DeleteUser(idUser);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Deletar Usuario";
                returnDto.MessageError = "Erro no processo de deletar o Usuário";
            }

            return await Task.FromResult(returnDto);
        }
    }
}
