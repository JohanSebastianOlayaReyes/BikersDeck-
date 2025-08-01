using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements;
using Entity.Model;

namespace Data.Interfaces
{
    public interface IPlayersData : IBaseModelData<Players>
    {
        Task<bool> UpdatePartial(Players players);
        Task<bool> ActiveAsync(int id, bool active);
        Task<Players> GetByIdAsync(int id);

    }
}
