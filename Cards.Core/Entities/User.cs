using System;
using System.Collections.Generic;
using Cards.Core.Helpers;
using Cards.Core.Services;

namespace Cards.Core.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Note> Notes { get; set; }

        public User(string email, string name)
        {
            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new CardException("Empty password", $"Password can not be empty.");
            }
            Salt = encrypter.GetSalt(password);
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password, Salt));

    }
}