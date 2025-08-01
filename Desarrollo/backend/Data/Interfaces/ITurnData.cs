using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements;
using Entity.Model;

namespace Data.Interfaces
{
    public interface ITurnData : IBaseModelData<Turn>
    {
        Task<bool> UpdatePartial(Turn turn);
        Task<bool> ActiveAsync(int id, bool active);
        Task<Turn> GetByIdAsync(int id);

    }
}