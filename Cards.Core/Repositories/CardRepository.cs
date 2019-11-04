using Cards.Core.EF;
using Cards.Core.Entities;
using Cards.Core.Repositories;

namespace Cards.Core.Repositories
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(CardContext context) : base(context)
        {
        }
    }
}