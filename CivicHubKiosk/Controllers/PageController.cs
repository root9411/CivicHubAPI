using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Application.Application.Dtos;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Application.Interface;
using SharedLibrary.Interfaces;

namespace CivicHubKiosk.Controllers
{
    [ApiController]
    [Route("api/kiosk")]
    public class PageController : Controller
    {


        private readonly IPageRepository _pageRepository;

        public PageController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }



        [HttpGet("GetPageData")]
        public async Task<IActionResult> GetPageData([FromQuery] string pageKey)
            {
            var data = await _pageRepository.GetPageContantAsync(pageKey);
                        
            return Ok(data);
        }


    }
}
