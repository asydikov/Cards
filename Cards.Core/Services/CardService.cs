using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Cards.Core.Entities;
using Cards.Core.Models;
using Cards.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cards.Core.Services
{
    public class CardService : ServiceBase<CardModel, Card>, ICardService
    {
        private readonly ICardRepository _repository;

        private readonly IMapper _mapper;

        public CardService(ICardRepository repository, IMapper mapper)
        : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<IEnumerable<CardModel>> GetAllAsync()
        {
            IEnumerable<Card> entities = await _repository.Find(x => x.UserId == UserId);
            return _mapper.Map<IEnumerable<Card>, IEnumerable<CardModel>>(entities);
        }

        public override async Task<Guid> CreateAsync(CardModel model)
        {
            var entity = _mapper.Map<Card>(model);
            entity.Id = Guid.NewGuid();
            entity.UserId = UserId;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            return await _repository.CreateAsync(entity);
        }
        public override async Task UpdateAsync(CardModel model)
        {
            model.UpdatedAt = DateTime.Now;
            var entity = _mapper.Map<Card>(model);
            await _repository.UpdateAsync(entity);
        }

    }
}