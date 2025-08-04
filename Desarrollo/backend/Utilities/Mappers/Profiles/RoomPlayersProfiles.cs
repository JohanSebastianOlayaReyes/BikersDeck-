using AutoMapper;
using Entity.Dtos.PedidoDto;
using Entity.Model;

public class RoomPlayerProfile : Profile
{
    public RoomPlayerProfile()
    {
        CreateMap<RoomPlayersDto, RoomPlayers>();
        CreateMap<RoomPlayers, RoomPlayersDto>();
    }
}
