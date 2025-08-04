using AutoMapper;
using Entity.Dtos.PizzaDto;
using Entity.Model;

public class MazoProfile : Profile
{
    public MazoProfile()
    {
        CreateMap<MazoDto, Mazo>();
        CreateMap<Mazo, MazoDto>();
    }
}
