using AutoMapper;
using Entity.Dtos.ClienteDto;
using Entity.Model;

namespace Utilities.Mappers.Profiles
{
    public class PlayersProfile : Profile
    {
        public PlayersProfile()
        {
            CreateMap<Players, GameDto>().ReverseMap();
            CreateMap<Players, GameUpdateDto>().ReverseMap();
        }
    }
}
