

using Cards.Core.EF;
using Cards.Core.Entities;

namespace Cards.Core.Repositories
{
    public class NoteRepository : RepositoryBase<Note>, INoteRepository
    {
        public NoteRepository(CardContext context) : base(context)
        {
        }
    }
}