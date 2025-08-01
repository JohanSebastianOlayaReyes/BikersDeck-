using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements;
using Entity.Model;

namespace Data.Interfaces
{
    public interface IGameData : IBaseModelData<Game>
    {
        Task<bool> UpdatePartial(Game game);
        Task<bool> ActiveAsync(int id, bool active);
        Task<Game> GetByIdAsync(int id);

    }
}