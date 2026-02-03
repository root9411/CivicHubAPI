using Microsoft.AspNetCore.Mvc;

namespace CivicHubAdmin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("CivicHubAdmin API Service is running.");
        }
    }
}
