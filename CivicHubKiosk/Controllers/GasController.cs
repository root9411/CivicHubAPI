using CivicHubKiosk.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Interfaces;

namespace CivicHubKiosk.Controllers
{
    [ApiController]
    [Route("api/kiosk/gas")]
    public class GasController : ControllerBase
    {
        private readonly IGasRepository _gasRepository;
        private readonly IEncryptionService _encryptionService;
        public GasController(IGasRepository gasRepository)
        {
            _gasRepository = gasRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _gasRepository.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("provider")]
        public async Task<IActionResult> GetProvider()
        {
            var provider = await _gasRepository.GetProvidersAsync();
            return Ok(provider);
        }
        [HttpGet("district")]
        public async Task<IActionResult> GetDistrict([FromQuery] string provider)
        {
            var district = await _gasRepository.GetDistrictByProviderAsync(provider);
            return Ok(district);
        }
        [HttpGet("subDistrict")]
        public async Task<IActionResult> GetsubDistrict([FromQuery] string district)
        {
            var subDistrict = await _gasRepository.GetsubDistrictByDistrictAsync(district);
            return Ok(subDistrict);
        }


    }
}
