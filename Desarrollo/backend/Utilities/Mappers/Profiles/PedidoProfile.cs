using AutoMapper;
using Entity.Dtos.PedidoDto;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class PedidoProfile :Profile
    {
        public PedidoProfile()
        {
            CreateMap<RoomPlayers, RoomPlayersDto>().ReverseMap();

        }

    }
}
