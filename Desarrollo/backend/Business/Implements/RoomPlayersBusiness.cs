using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dtos.PedidoDto;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.RoomPlayersDto;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class RoomPlayersBusiness : BaseBusiness<RoomPlayers, RoomPlayersDto>, IRoomPlayersBusiness
    {
        private readonly IRoomPlayersData _roomPlayersData;

        public RoomPlayersBusiness(
            IRoomPlayersData roomPlayersData,
            IMapper mapper,
            ILogger<RoomPlayersBusiness> logger)
            : base(roomPlayersData, mapper, logger)
        {
            _roomPlayersData = roomPlayersData;
        }

        /// <summary>
        /// Actualiza parcialmente una relación RoomPlayers existente.
        /// </summary>
        public async Task<bool> UpdatePartialRoomPlayersAsync(UpdateRoomPlayersDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var entity = _mapper.Map<RoomPlayers>(dto);
            var result = await _roomPlayersData.UpdatePartial(entity);
            return result;
        }

        /// <summary>
        /// Desactiva una relación RoomPlayers (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicRoomPlayerAsync(DeleteLogicRoomPlayersDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID es inválido.");

            var exists = await _roomPlayersData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("roomplayers", dto.Id);

            return await _roomPlayersData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
