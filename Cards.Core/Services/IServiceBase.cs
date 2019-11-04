using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cards.Core.Models;

namespace Cards.Core.Services
{
    public interface IServiceBase<TModel> where TModel : ModelBase
    {
        Task<TModel> GetAsync(Guid id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<Guid> CreateAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteEntityAsync(Guid id);

        Guid UserId { get; set; }
    }
}
