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
        private readonly IEncryptionService _encryptionService;
        public PageController(IPageRepository pageRepository, IEncryptionService encryptionService)
        {
            _pageRepository = pageRepository;
            _encryptionService = encryptionService;
        }



        [HttpGet("GetPageData")]
        public async Task<IActionResult> GetPageData([FromQuery] string pageKey)
        {

            var decryptPageKey = _encryptionService.DecryptData<string>(pageKey);

            var data = await _pageRepository.GetPageContantAsync(decryptPageKey);

            //return Ok(data);
            return Ok(new EncryptedPayload
            {
                Payload = _encryptionService.EncryptData(data)
            });
        }


        [HttpGet("GetLanguages")]
        public async Task<IActionResult> GetLanguages()
        {
            var data = await _pageRepository.GetLanguagesAsync();

            return Ok(data);
        }




    }
}
