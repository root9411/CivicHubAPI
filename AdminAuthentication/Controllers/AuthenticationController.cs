using Microsoft.AspNetCore.Mvc;

namespace AdminAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Authentication Service is running.");
        }




    }
}
