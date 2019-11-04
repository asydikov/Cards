
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cards.Core.Entities;
using Cards.Core.Models;
using Cards.Core.Repositories;

namespace Cards.Core.Services
{
    public class RepeatRateService : ServiceBase<RepeatRateModel, RepeatRate>, IRepeatRateService
    {
        private readonly IRepeatRateRepository _repository;
        private readonly IMapper _mapper;

        public RepeatRateService(IRepeatRateRepository repository, IMapper mapper)
        : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<IEnumerable<RepeatRateModel>> GetAllAsync()
        {
            IEnumerable<RepeatRate> entities = await _repository.GetAllOrderBy(x => x.Sort);
            return _mapper.Map<IEnumerable<RepeatRate>, IEnumerable<RepeatRateModel>>(entities);
        }
    }
}