using AutoMapper;
using Entity.Dtos.PizzaDto;
using Entity.Model;

public class RoundProfile : Profile
{
    public RoundProfile()
    {
        CreateMap<RoundDto, Round>();
        CreateMap<Round, RoundDto>();
    }
}
