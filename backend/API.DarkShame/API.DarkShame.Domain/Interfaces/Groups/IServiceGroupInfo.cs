using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DarkShame.Domain.Dto.Request.Groups;
using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities;

namespace API.DarkShame.Domain.Interfaces.Groups
{
    public interface IServiceGroupInfo
    {
        Task<List<GroupInfo>> GetGroup();
        Task<GroupInfo> GroupId(string idGroup);
        Task<ReturnDto> CreateGroup(GroupInfo groupInfo);
        Task<ReturnDto> UpdateGroup(GroupInfoRequestDto groupInfoRequestDto);
        Task<ReturnDto> DeleteGroup(string idGroup);
    }
}