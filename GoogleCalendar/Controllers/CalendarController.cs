using GoogleCalendar.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoogleCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateGoogleCalendar([FromBody] Models.GoogleCalendar request)
        {
            var result =await GoogleCalendarHelper.CreateGoogleCalendar(request);
            return Ok(result.Status);
        }
    }
}
