using AutoMapper;
using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.Dtos.ClienteDto;
using Entity.Dtos.PedidoDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using ValidationException = Utilities.Exceptions.ValidationException;

namespace Business.Implements
{
    public class RoomPlayersBusiness : BaseBusiness<RoomPlayers, RoomPlayersDto>, IRoomPlayersBusiness
    {
        private readonly IRoomPlayersData _clienteData;
        private readonly IValidator<RoomPlayersDto> _validator;
        private object roomplayersData;

        public RoomPlayersBusiness(IRoomPlayersData roomplayersData, IMapper mapper, ILogger<RoomPlayersBusiness> logger)
            : base( roomplayersData, mapper, logger)
        {
            roomplayersData = roomplayersData;
        }

        public async Task<bool> UpdatePartialAsync(RoomPlayersUpdateDto dto)
        {
            if (dto == null || dto.Id == 0)
                return false;

            var roomplayers = _mapper.Map<RoomPlayers>(dto);

            return await roomplayersData.UpdatePartial(roomplayers);
        }

        public async Task<bool> ActiveAsync(RoomPlayersaActiveDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del ... es inválido");

            var exists = await roomplayersData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("...", dto.Id);

            return await roomplayersData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
