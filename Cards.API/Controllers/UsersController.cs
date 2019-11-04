
using System.Threading.Tasks;
using Cards.Core.Auth;
using Cards.Core.Models;
using Cards.Core.Models.OkResponses;
using Cards.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController<UserModel, IUSerService>
    {
        public UsersController(IUSerService service)
        : base(service) { }

        [AllowAnonymous]
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {
            await Service.CreateAsync(model);
            var user = await Service.LoginAsync(model.Email, model.Password);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserModel model)
        {
            var user = await Service.LoginAsync(model.Email, model.Password);

            return Ok(user);
        }

    }
}