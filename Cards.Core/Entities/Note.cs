using System;

namespace Cards.Core.Entities
{
    public class Note : EntityBase
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}