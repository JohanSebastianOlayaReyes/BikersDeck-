using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Implements;
using Entity.Model;

namespace Data.Interfaces
{
    public interface IRoomPlayersData : IBaseModelData<RoomPlayers>
    {
        Task<bool> UpdatePartial(RoomPlayers roomplayers);
        Task<bool> ActiveAsync(int id, bool active);
        Task<RoomPlayers> GetByIdAsync(int id);

    }
}