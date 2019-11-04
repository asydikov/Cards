
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cards.Core.Entities;
using Cards.Core.Models;
using Cards.Core.Repositories;

namespace Cards.Core.Services
{
    public class CategoryService : ServiceBase<CategoryModel, Category>, ICategoryService
    {
        private readonly ICategoryRepository _repository;

        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            IEnumerable<Category> entities = await _repository.GetAllOrderBy(x => x.Sort);
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(entities);
        }
    }
}