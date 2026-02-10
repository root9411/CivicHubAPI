using CivicHubKiosk.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Interfaces;

namespace CivicHubKiosk.Controllers
{
    [ApiController]
    [Route("api/kiosk/water")]
    public class waterController : ControllerBase
    {
        private readonly IWaterReppository _waterRepository;
        private readonly IEncryptionService _encryptionService;
        public waterController(IWaterReppository waterRepository)
        {
            _waterRepository = waterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _waterRepository.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("boards")]
        public async Task<IActionResult> GetBoards()
        {
            var boards = await _waterRepository.GetBoardsAsync();
            return Ok(boards);
        }
        [HttpGet("service")]
        public async Task<IActionResult> GetServices([FromQuery]string boards)
        {
            var service = await _waterRepository.GetserviceByboardsAsync(boards);
            return Ok(service);
        }
    }
}