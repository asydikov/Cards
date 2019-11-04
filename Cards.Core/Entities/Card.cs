using System;

namespace Cards.Core.Entities
{
    public class Card : EntityBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Word { get; set; }
        public string Meaning { get; set; }
        public string Note { get; set; }
        public bool IsSaved { get; set; }
        public Guid ModeId { get; set; }
        public Mode Mode { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid RepeatRateId { get; set; }
        public RepeatRate RepeatRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}