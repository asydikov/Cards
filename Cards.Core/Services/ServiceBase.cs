using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cards.Core.Entities;
using Cards.Core.Models;
using Cards.Core.Repositories;

namespace Cards.Core.Services
{
    public abstract class ServiceBase<TModel, TEntity> : IServiceBase<TModel>
    where TModel : ModelBase
    where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IMapper _mapper;
        public Guid UserId { get; set; }

        public ServiceBase(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TModel> GetAsync(Guid id)
        {
            TEntity entity = await _repository.GetAsync(id);
            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);
        }

        public virtual async Task<Guid> CreateAsync(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            entity.Id = Guid.NewGuid();
            return await _repository.CreateAsync(entity);
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteEntityAsync(Guid id)
        {
            await _repository.DeleteEntityAsync(id);
        }
    }
}