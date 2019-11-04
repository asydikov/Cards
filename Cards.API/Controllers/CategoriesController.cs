
using Cards.Core.Models;
using Cards.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : BaseApiController<CategoryModel, ICategoryService>
    {
        public CategoriesController(ICategoryService service)
        : base(service) { }

    }

}