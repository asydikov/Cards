
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cards.Core.Entities;
using Cards.Core.Models;
using Cards.Core.Repositories;

namespace Cards.Core.Services
{
    public class ModeService : ServiceBase<ModeModel, Mode>, IModeService
    {
        private readonly IModeRepository _repository;
        private readonly IMapper _mapper;

        public ModeService(IModeRepository repository, IMapper mapper)
        : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<IEnumerable<ModeModel>> GetAllAsync()
        {
            IEnumerable<Mode> entities = await _repository.GetAllOrderBy(x => x.Sort);
            return _mapper.Map<IEnumerable<Mode>, IEnumerable<ModeModel>>(entities);
        }
    }
}