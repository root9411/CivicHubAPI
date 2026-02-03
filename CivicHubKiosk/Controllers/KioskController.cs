using Microsoft.AspNetCore.Mvc;

namespace CivicHubKiosk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KioskController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(new { status = "Kiosk is operational." });
        }





    }
}
