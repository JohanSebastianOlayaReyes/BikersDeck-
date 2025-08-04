using AutoMapper;
using Business.Interfaces;
using Data.Interface;
using Entity.Dto.Client;
using Entity.Dtos.CardDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business.Implements
{
    public class CardBusiness : BaseBusiness<Card, CardDto>, ICardBusiness
    {
        private readonly ICardData _cardData;

        public CardBusiness(
            ICardData cardData,
            IMapper mapper,
            ILogger<CardBusiness> logger)
            : base(cardData, mapper, logger)
        {
            _cardData = cardData;
        }

        /// <summary>
        /// Actualiza parcialmente una carta existente.
        /// </summary>
        public async Task<bool> UpdatePartialCardAsync(UpdateCard dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("ID inválido.");

            var card = _mapper.Map<Card>(dto);
            var result = await _cardData.UpdatePartial(card);
            return result;
        }

        /// <summary>
        /// Desactiva una carta (eliminación lógica).
        /// </summary>
        public async Task<bool> DeleteLogicCardAsync(DeleteLogicCardDto dto)
        {
            if (dto == null || dto.Id <= 0)
                throw new ValidationException("Id", "El ID de la carta es inválido.");

            var exists = await _cardData.GetByIdAsync(dto.Id)
                ?? throw new EntityNotFoundException("carta", dto.Id);

            return await _cardData.ActiveAsync(dto.Id, dto.Status);
        }
    }
}
