
using Cards.Core.Models;
using Cards.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModesController : BaseApiController<ModeModel, IModeService>
    {
        public ModesController(IModeService service)
        : base(service) { }



    }
}