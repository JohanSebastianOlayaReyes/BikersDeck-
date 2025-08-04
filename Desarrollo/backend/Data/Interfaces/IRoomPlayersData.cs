using Entity.Model;

namespace Data.Interface
{
    public interface IRoomPlayersData : IBaseModelData<RoomPlayers>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(RoomPlayers roomPlayers);
        void RegisterPlayers(int PlayersId, string NamePlayers);
        List<string> GetPlayers(int PlayersId);
    }
}
