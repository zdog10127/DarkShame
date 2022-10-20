using API.DarkShame.Domain.Entities.Store.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Store.Game
{
    public interface IRepositorySpecifications
    {
        //Specifications Minimum
        Task<SpecificationsMinimum> GetSpecificationsMinimum(string idGame);
        Task CreateSpecificationsMinimum(SpecificationsMinimum specificationsMinimum);

        //Specifications Maximum
        Task<SpecificationsMaximum> GetSpecificationsMaximum(string idGame);
        Task CreateSpecificationsMaximum(SpecificationsMaximum specificationsMaximum);
    }
}
