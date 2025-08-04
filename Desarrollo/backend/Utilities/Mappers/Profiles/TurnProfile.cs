using AutoMapper;
using Entity.Dtos.PizzaDto;
using Entity.Model;

public class TurnProfile : Profile
{
    public TurnProfile()
    {
        CreateMap<TurnDto, Turn>();
        CreateMap<Turn, TurnDto>();
    }
}
