using System.Collections.Generic;
using System.Linq;
using Cards.Core.EF;
using Cards.Core.Entities;

namespace Cards.Core.Repositories
{
    public class RepeatRateRepository : RepositoryBase<RepeatRate>, IRepeatRateRepository
    {
        public RepeatRateRepository(CardContext context) : base(context)
        {
        }
    }
}