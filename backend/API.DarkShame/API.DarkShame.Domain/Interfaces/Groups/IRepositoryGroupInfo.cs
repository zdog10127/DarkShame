using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DarkShame.Domain.Dto.Request.Groups;
using API.DarkShame.Domain.Entities;

namespace API.DarkShame.Domain.Interfaces.Groups
{
    public interface IRepositoryGroupInfo
    {
        Task<List<GroupInfo>> GetGroup();
        Task<GroupInfo> GroupId(string idGroup);
        Task CreateGroup(GroupInfo groupInfo);
        Task UpdateGroup(GroupInfoRequestDto groupInfoRequestDto);
        Task DeleteGroup(string idGroup);
    }
}