using System;
using System.Collections.Generic;

namespace Cards.Core.Entities
{
    public class RepeatRate : EntityBase
    {
        public string Name { get; set; }
        public int Sort { get; set; }
        public ICollection<Card> Cards { get; set; }

    }
}