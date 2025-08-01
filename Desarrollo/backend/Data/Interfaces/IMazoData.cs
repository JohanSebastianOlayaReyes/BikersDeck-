using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements;
using Entity.Model;

namespace Data.Interfaces
{
    public interface IMazoData : IBaseModelData<Mazo>
    {
        Task<bool> UpdatePartial(Mazo mazo);
        Task<bool> ActiveAsync(int id, bool active);
        Task<Mazo> GetByIdAsync(int id);

    }
}