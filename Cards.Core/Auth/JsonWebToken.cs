using Cards.Core.Models;

namespace Cards.Core.Auth
{
    public class JsonWebToken
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}