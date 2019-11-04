
using AutoMapper;
using Cards.Core.Entities;
using Cards.Core.Models;
using Cards.Core.Repositories;

namespace Cards.Core.Services
{
    public class NoteService : ServiceBase<NoteModel, Note>, INoteService
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository repository, IMapper mapper)
        : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}