using System.Threading.Tasks;
using Cards.Core.Auth;
using Cards.Core.Models;

namespace Cards.Core.Services
{
    public interface IUSerService : IServiceBase<UserModel>
    {
        Task<UserModel> GetByEmailAsync(string email);
        Task<UserModel> LoginAsync(string email, string password);
    }
}