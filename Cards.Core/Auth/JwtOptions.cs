namespace Cards.Core.Auth
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpiryMiutes { get; set; }
        public string Issuer { get; set; }
    }
}