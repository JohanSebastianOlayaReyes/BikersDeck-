using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.PlayersDto;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class PlayerBusiness : BaseBusiness<Players, PlayersDto>, IPlayerBusiness
    {
        private readonly IPlayerData _playerData;

        public PlayerBusiness(
            IPlayerData playerData,
            IMapper mapper,
            ILogger<PlayerBusiness> logger)
            : base(playerData, mapper, logger)
        {
            _playerData = playerData;
        }

        /// <summary>
        /// Actualiza parcialmente un jugador existente.
        /// </summary>
        public async Task<bool> UpdatePartialPlayerAsync(UpdatePlayersDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var player = _mapper.Map<Players>(dto);
            var result = await _playerData.UpdatePartial(player);
            return result;
        }

        /// <summary>
        /// Desactiva un jugador (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicPlayerAsync(DeleteLogicPlayersDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del jugador es inválido.");

            var exists = await _playerData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("jugador", dto.Id);

            return await _playerData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
