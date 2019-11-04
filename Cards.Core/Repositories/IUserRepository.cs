using System.Threading.Tasks;
using Cards.Core.Entities;

namespace Cards.Core.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}