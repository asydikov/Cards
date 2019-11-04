using System;
using System.Threading.Tasks;

using AutoMapper;
using Cards.Core.Auth;
using Cards.Core.Entities;
using Cards.Core.Helpers;
using Cards.Core.Models;
using Cards.Core.Repositories;

namespace Cards.Core.Services
{
    public class UserService : ServiceBase<UserModel, User>, IUSerService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository repository, IMapper mapper, IEncrypter encrypter, IJwtHandler jwtHandler)
        : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        public Task<UserModel> GetByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserModel> LoginAsync(string email, string password)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                throw new CardException("Invalid Credentials", $"Invalid credentials.");
            }

            User entity = await _repository.GetByEmailAsync(email);
            if (entity == null)
            {
                throw new CardException("Invalid Credentials", $"Invalid credentials.");
            }
            if (!entity.ValidatePassword(password, _encrypter))
            {
                throw new CardException("Invalid Credentials", $"Invalid credentials.");
            }

            var jwtWebToken = _jwtHandler.Create(entity.Id);
            var model = _mapper.Map<UserModel>(entity);
            model.Token = jwtWebToken.Token;
            model.Expires = jwtWebToken.Expires;
            return model;
        }

        public override async Task<Guid> CreateAsync(UserModel model)
        {
            User user = await _repository.GetByEmailAsync(model.Email);

            if (user != null)
            {
                throw new CardException("Email in use", $"Email: '{model.Email} is already in use");
            }

            User entity = new User(model.Email, model.Name);
            entity.SetPassword(model.Password, _encrypter);

            return await _repository.CreateAsync(entity);
        }
    }
}