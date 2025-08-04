using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dtos.ClienteDto;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class GameBusiness : BaseBusiness<Game, GameDto>, IGameBusiness
    {
        private readonly IGameData _gameData;

        public GameBusiness(
            IGameData gameData,
            IMapper mapper,
            ILogger<GameBusiness> logger)
            : base(gameData, mapper, logger)
        {
            _gameData = gameData;
        }

        /// <summary>
        /// Actualiza parcialmente un juego existente.
        /// </summary>
        public async Task<bool> UpdatePartialGameAsync(UpdateGameDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var game = _mapper.Map<Game>(dto);
            var result = await _gameData.UpdatePartial(game);
            return result;
        }

        /// <summary>
        /// Desactiva un juego (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicGameAsync(DeleteLogicGameDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del juego es inválido.");

            var exists = await _gameData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("juego", dto.Id);

            return await _gameData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
