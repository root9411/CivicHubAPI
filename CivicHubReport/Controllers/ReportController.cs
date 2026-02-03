using Microsoft.AspNetCore.Mvc;

namespace CivicHubReport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetReport()
        {
            return Ok("CivicHub Report is running.");
        }



    }
}
