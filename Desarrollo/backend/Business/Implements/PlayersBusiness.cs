using AutoMapper;
using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.Dtos.ClienteDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;

namespace Business.Implements
{
    public class PlayersBusiness : BaseBusiness<Players, PlayersDto>, IPlayersBusiness
    {
        private readonly IPlayersData _PlayersData;
        private readonly IValidator<PlayersDto> _validator;

        public PlayersBusiness(IPlayersData playersData, IMapper mapper, ILogger<PlayersBusiness> logger)
            : base(playersData, mapper, logger)
        {
            _PlayersData = playersData;
        }

        public async Task<bool> UpdatePartialAsync(PlayersUpdateDto dto)
        {
            if (dto == null || dto.Id == 0)
                return false;

            var players = _mapper.Map<Players>(dto);

            return await _PlayersData.UpdatePartial(players);
        }

        public async Task<bool> ActiveAsync(RoomPlayersaActiveDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del ... es inválido");

            var exists = await _PlayersData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("...", dto.Id);

            return await _PlayersData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
