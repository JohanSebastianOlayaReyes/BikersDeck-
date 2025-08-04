using Entity.Dtos.PlayersDto;
using Entity.Model;

namespace Data.Interface
{
    public interface IPlayerData : IBaseModelData<Players>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(Players player);
        int Quantity(int QuantityPlayer);//crea un registro y devuelve un id
        int GetQuantity(int PlayersId);//obtine la cantidad maxima de jugadores 
    }
}
