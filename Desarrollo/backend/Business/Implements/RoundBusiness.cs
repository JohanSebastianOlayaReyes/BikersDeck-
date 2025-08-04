using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.RoundDto;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class RoundBusiness : BaseBusiness<Round, RoundDto>, IRoundBusiness
    {
        private readonly IRoundData _roundData;

        public RoundBusiness(
            IRoundData roundData,
            IMapper mapper,
            ILogger<RoundBusiness> logger)
            : base(roundData, mapper, logger)
        {
            _roundData = roundData;
        }

        /// <summary>
        /// Actualiza parcialmente una ronda existente.
        /// </summary>
        public async Task<bool> UpdatePartialRoundAsync(UpdateRoundDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var round = _mapper.Map<Round>(dto);
            var result = await _roundData.UpdatePartial(round);
            return result;
        }

        /// <summary>
        /// Desactiva una ronda (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicRoundAsync(DeleteLogicRoundDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID de la ronda es inválido.");

            var exists = await _roundData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("ronda", dto.Id);

            return await _roundData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
