using System;
using System.Threading.Tasks;
using Cards.Core.EF;
using Cards.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cards.Core.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CardContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());
        }
    }
}