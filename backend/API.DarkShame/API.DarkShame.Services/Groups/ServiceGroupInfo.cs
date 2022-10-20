using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DarkShame.Domain.Dto.Request.Groups;
using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Interfaces.Groups;
using API.DarkShame.Infra.Repository.Groups;

namespace API.DarkShame.Services.Groups
{
    public class ServiceGroupInfo : IServiceGroupInfo
    {
        private readonly IRepositoryGroupInfo _repositoryGroupInfo;

        public ServiceGroupInfo()
        {
            _repositoryGroupInfo = new RepositoryGroupInfo();
        }

        public async Task<List<GroupInfo>> GetGroup()
        {
            var groups = await _repositoryGroupInfo.GetGroup();
            return groups;
        }

        public async Task<GroupInfo> GroupId(string idGroup)
        {
            var groupId = await _repositoryGroupInfo.GroupId(idGroup);
            return groupId;
        }

        public async Task<ReturnDto> CreateGroup(GroupInfo groupInfo)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryGroupInfo.CreateGroup(groupInfo);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Grupo";
                returnDto.MessageError = "Erro no processo de gravar Grupo";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> UpdateGroup(GroupInfoRequestDto groupInfoRequestDto)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryGroupInfo.UpdateGroup(groupInfoRequestDto);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Atualizar Grupo";
                returnDto.MessageError = "Erro no processo de atualizar Grupo";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> DeleteGroup(string idGroup)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryGroupInfo.DeleteGroup(idGroup);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Deletar Grupo";
                returnDto.MessageError = "Erro no processo de deletar Grupo";
            }

            return await Task.FromResult(returnDto);
        }

    }
}