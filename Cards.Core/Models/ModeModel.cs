using System;

namespace Cards.Core.Models
{
    public class ModeModel : ModelBase
    {
        public string PrimaryLang { get; set; }
        public string SecondaryLang { get; set; }
        public int Sort { get; set; }

    }
}