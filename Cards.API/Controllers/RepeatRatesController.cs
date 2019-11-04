
using Cards.Core.Models;
using Cards.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepeatRatesController : BaseApiController<RepeatRateModel, IRepeatRateService>
    {
        public RepeatRatesController(IRepeatRateService service)
        : base(service) { }



    }
}