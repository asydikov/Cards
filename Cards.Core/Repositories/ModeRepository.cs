using System.Collections.Generic;
using System.Linq;
using Cards.Core.EF;
using Cards.Core.Entities;

namespace Cards.Core.Repositories
{
    public class ModeRepository : RepositoryBase<Mode>, IModeRepository
    {
        public ModeRepository(CardContext context) : base(context)
        {
        }
    }
}