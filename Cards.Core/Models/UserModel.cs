
namespace Cards.Core.Models
{
    public class UserModel : ModelBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}