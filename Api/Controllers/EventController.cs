using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("api/v1/events")]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public int GetAllEvents()
        {
            return 0;
        }
    }
}