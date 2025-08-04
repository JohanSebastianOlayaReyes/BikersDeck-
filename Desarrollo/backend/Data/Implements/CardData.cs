using Back_end.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class CardData : BaseModelData<Card>, ICardData
    {
        public CardData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var card = await _context.Set<Card>().FindAsync(id);
            if (card == null)
                return false;

            card.Status = active;
            card.DeleteAt = DateTime.UtcNow;

            _context.Entry(card).Property(c => c.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Card card)
        {
            var existingCard = await _context.Cards.FindAsync(card.Id);
            if (existingCard == null)
                return false;

            existingCard.photo = card.photo;
            existingCard.Name = card.Name;
            existingCard.Displacement = card.Displacement;
            existingCard.power = card.power;
            existingCard.Torque = card.Torque;
            existingCard.speed = card.speed;
            existingCard.model = card.model;
            existingCard.CylinderNumber = card.CylinderNumber;

            _context.Entry(existingCard).Property(c => c.photo).IsModified = true;
            _context.Entry(existingCard).Property(c => c.Name).IsModified = true;
            _context.Entry(existingCard).Property(c => c.Displacement).IsModified = true;
            _context.Entry(existingCard).Property(c => c.power).IsModified = true;
            _context.Entry(existingCard).Property(c => c.Torque).IsModified = true;
            _context.Entry(existingCard).Property(c => c.speed).IsModified = true;
            _context.Entry(existingCard).Property(c => c.model).IsModified = true;
            _context.Entry(existingCard).Property(c => c.CylinderNumber).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
