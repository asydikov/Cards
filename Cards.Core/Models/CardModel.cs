using System;

namespace Cards.Core.Models
{
    public class CardModel : ModelBase
    {
        public Guid UserId { get; set; }
        public string Word { get; set; }
        public string Meaning { get; set; }
        public string Note { get; set; }
        public bool IsSaved { get; set; }
        public Guid ModeId { get; set; }
        public ModeModel Mode { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public Guid RepeatRateId { get; set; }
        public RepeatRateModel RepeatRate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}