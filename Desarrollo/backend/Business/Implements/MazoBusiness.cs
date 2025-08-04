using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dtos.MazoDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class MazoBusiness : BaseBusiness<Mazo, MazoDto>, IMazoBusiness
    {
        private readonly IMazoData _mazoData;

        public MazoBusiness(
            IMazoData mazoData,
            IMapper mapper,
            ILogger<MazoBusiness> logger)
            : base(mazoData, mapper, logger)
        {
            _mazoData = mazoData;
        }

        /// <summary>
        /// Actualiza parcialmente un mazo existente.
        /// </summary>
        public async Task<bool> UpdatePartialMazoAsync(UpdateMazoDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var mazo = _mapper.Map<Mazo>(dto);
            var result = await _mazoData.UpdatePartial(mazo);
            return result;
        }

        /// <summary>
        /// Desactiva un mazo (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicMazoAsync(DeleteLogicMazoDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID del mazo es inválido.");

            var exists = await _mazoData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("mazo", dto.Id);

            return await _mazoData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
