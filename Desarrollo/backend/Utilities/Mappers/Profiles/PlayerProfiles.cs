using AutoMapper;
using Entity.Dtos.PlayersDto;
using Entity.Model;

public class PlayersProfile : Profile
{
    public PlayersProfile()
    {
        CreateMap<Players, PlayersDto>().ReverseMap();
    }
}
