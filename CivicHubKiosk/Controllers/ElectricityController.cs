using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Interfaces;

namespace CivicHubKiosk.Controllers
{
   
    [ApiController]
    [Route("api/kiosk/electricity")]
    public class ElectricityController : ControllerBase
    {
        private readonly IElectricityRepository _electricityRepository;
        private readonly IEncryptionService _encryptionService;

        public ElectricityController(IElectricityRepository electricityRepository)
        {
            _electricityRepository = electricityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _electricityRepository.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("states")]
        public async Task<IActionResult> GetStates()
        {
            var states = await _electricityRepository.GetStatesAsync();
            return Ok(states);
        }

        [HttpGet("boards")]
        public async Task<IActionResult> GetBoards([FromQuery]string state)
        {
            var boards = await _electricityRepository.GetBoardsByStateAsync(state);
            return Ok(boards);
        }
    }
}