using System;
using System.Collections.Generic;

namespace Cards.Core.Entities
{
    public class Mode : EntityBase
    {
        public string PrimaryLang { get; set; }
        public string SecondaryLang { get; set; }
        public int Sort { get; set; }
        public ICollection<Card> Cards { get; set; }

    }
}