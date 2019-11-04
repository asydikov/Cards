using System.Collections.Generic;
using System.Linq;
using Cards.Core.EF;
using Cards.Core.Entities;

namespace Cards.Core.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(CardContext context) : base(context)
        {
        }
    }
}