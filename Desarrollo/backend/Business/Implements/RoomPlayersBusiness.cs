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

        public RoomPlayersBusiness(IRoomPlayersData roomplayersData, IMapper mapper, ILogger<RoomPlayersBusiness> logger)
            : base( roomplayersData, mapper, logger)
        {
            _rommplayersData = roomplayersData;
        }

        public async Task<bool> UpdatePartialAsync(RoomPlayersUpdateDto dto)
        {
            if (dto == null || dto.Id == 0)
                return false;

            var roomplayers = _mapper.Map<RoomPlayers>(dto);

            return await _clienteData.UpdatePartial(roomplayers);
        }

        public async Task<bool> ActiveAsync(RoomPlayersaActiveDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del ... es inválido");

            var exists = await _clienteData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("...", dto.Id);

            return await _clienteData.ActiveAsync(dto.Id, dto.Active);
        }
    }
}
