using System.Collections.Generic;


namespace Cards.Core.Models.OkResponses
{
    public class DictionaryOkResponse : OkResponse<CardModel>
    {
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<ModeModel> Modes { get; set; }
        public IEnumerable<RepeatRateModel> RepeatRates { get; set; }
    }
}