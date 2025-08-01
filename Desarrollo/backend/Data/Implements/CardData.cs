using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Model;

namespace Data.Implements
{
    public class CardData : BaseModelData<Card>, ICardData
    {
        public CardData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> UpdatePartial(Card card)
        {
            var existingCard = await _dbSet.FindAsync(card.Id);
            foreach (var prop in typeof(Card).GetProperties().Where(p => p.CanWrite && p.Name != "Id"))
            {
                var val = prop.GetValue(card);
                if (val != null && (!(val is string s) || !string.IsNullOrWhiteSpace(s)))
                    prop.SetValue(existingCard, val);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var card = await _context.Set<Card>().FindAsync(id);
            if (card == null)
                return false;

            card.Active = active;
            _context.Entry(card).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
