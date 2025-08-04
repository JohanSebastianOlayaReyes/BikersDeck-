using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.PlayersDto;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class PlayerBusiness : BaseBusiness<Players, PlayersDto>, IPlayerBusiness
    {
        private readonly IPlayerData _playerData;
        private readonly IRoomPlayersData _roomPlayerData;

        private readonly IMapper _mapper;
        private readonly ILogger<PlayerBusiness> _logger;

        // Constructor completo con inyección de dependencias
        public PlayerBusiness(
            IPlayerData playerData,
            IRoomPlayersData roomPlayersData,
            IMapper mapper,
            ILogger<PlayerBusiness> logger)
            : base(playerData, mapper, logger)
        {
            _playerData = playerData ?? throw new ArgumentNullException(nameof(playerData));
            _roomPlayerData = roomPlayersData ?? throw new ArgumentNullException(nameof(roomPlayersData));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Actualiza parcialmente un jugador existente.
        /// </summary>
        public async Task<bool> UpdatePartialPlayerAsync(UpdatePlayersDto dto)
        {
            if (dto == null || dto.Id <= 0)
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

        public int Quantity(int quantityPlayer)
        {
            return _playerData.GetQuantity(quantityPlayer);
        }

        public void RegisterPlayers(int playersId, string namePlayers)
        {
            int max = _playerData.GetQuantity(playersId);
            int registered = _roomPlayerData.GetPlayers(playersId).Count;

            if (registered >= max)
                throw new InvalidOperationException("Ya alcanzó el número máximo de jugadores");

            _roomPlayerData.RegisterPlayers(playersId, namePlayers);
        }

        public List<string> GetPlayers(int playersId)
        {
            return _roomPlayerData.GetPlayers(playersId);
        }

        public int GetQuantity(int playersId)
        {
            int max = _playerData.GetQuantity(playersId);
            int registered = _roomPlayerData.GetPlayers(playersId).Count;
            return max - registered;
        }
    }
}