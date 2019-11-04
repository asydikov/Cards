using System;

namespace Cards.Core.Models
{
    public class NoteModel : ModelBase
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}