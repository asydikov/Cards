
using Cards.Core.Models;
using Cards.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : BaseApiController<NoteModel, INoteService>
    {
        public NotesController(INoteService service)
        : base(service) { }

    }
}