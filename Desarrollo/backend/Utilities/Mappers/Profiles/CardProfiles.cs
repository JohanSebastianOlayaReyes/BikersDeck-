using AutoMapper;
using Entity.Dtos.PizzaDto;
using Entity.Model;

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<CardDto, Card>();
        CreateMap<Card, CardDto>();
    }
}
