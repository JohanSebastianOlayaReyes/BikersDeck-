using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.TurnDto;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class TurnBusiness : BaseBusiness<Turn, TurnDto>, ITurnBusiness
    {
        private readonly ITurnData _turnData;

        public TurnBusiness(
            ITurnData turnData,
            IMapper mapper,
            ILogger<TurnBusiness> logger)
            : base(turnData, mapper, logger)
        {
            _turnData = turnData;
        }

        /// <summary>
        /// Actualiza parcialmente un turno existente.
        /// </summary>
        public async Task<bool> UpdatePartialTurnAsync(UpdateTurnDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var turn = _mapper.Map<Turn>(dto);
            var result = await _turnData.UpdatePartial(turn);
            return result;
        }

        /// <summary>
        /// Desactiva un turno (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicTurnAsync(DeleteLogicTurnDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del turno es inválido.");

            var exists = await _turnData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("turno", dto.Id);

            return await _turnData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
