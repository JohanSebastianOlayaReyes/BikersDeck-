using AutoMapper;
using Entity.Dtos.ClienteDto;
using Entity.Model;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<GameDto, Game>();
        CreateMap<Game, GameDto>();
    }
}
