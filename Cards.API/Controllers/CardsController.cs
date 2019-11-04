using System.Linq;
using System.Threading.Tasks;
using Cards.Core.Models;
using Cards.Core.Models.OkResponses;
using Cards.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : BaseApiController<CardModel, ICardService>
    {
        public CardsController(ICardService service)
        : base(service) { }

        [HttpGet("dependencies")]
        public async Task<IActionResult> GetDependencies()
        {
            var categoryService = GetService<ICategoryService>();
            var repeatrateService = GetService<IRepeatRateService>();
            var modeService = GetService<IModeService>();

            var categories = await categoryService.GetAllAsync();
            var repeatRates = await repeatrateService.GetAllAsync();
            var modes = await modeService.GetAllAsync();

            return Ok(new DictionaryOkResponse()
            {
                Categories = categories,
                RepeatRates = repeatRates,
                Modes = modes
            });
        }

    }
}
