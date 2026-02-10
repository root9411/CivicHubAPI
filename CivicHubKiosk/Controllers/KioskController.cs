using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Application.Features.Kiosks.Commands;
using SharedLibrary.Application.Interface;
using SharedLibrary.Interfaces;

[ApiController]
[Route("api/kiosk")]
public class KioskController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IKioskReadRepository _kioskReadRepository;
    private readonly IEncryptionService _encryptionService;

    public KioskController(IMediator mediator, IKioskReadRepository kioskReadRepository, IEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
        _mediator = mediator;
        _kioskReadRepository = kioskReadRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateKioskCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var kiosks = await _mediator.Send(new GetActiveKiosksQuery());
        return Ok(kiosks);
    }


    [HttpGet("IsActive")]
    public async Task<IActionResult> IsActive([FromQuery] string encryptedKioskIP)
    {
        var data = _encryptionService.DecryptData<string>(encryptedKioskIP);
        var isActive = true;
        return Ok(isActive);
    }


    [HttpGet("languages/{kioskId}")]
    public async Task<IActionResult> GetLanguages(int kioskId)
    {
        return Ok(await _mediator.Send(
            new GetLanguagesQuery(kioskId)));
    }

    [HttpGet("departments")]
    public async Task<IActionResult> GetDepartments()
    {

        var kiosks = await _kioskReadRepository.GetDepartmentsAsync();
        return Ok();

        //return Ok(await _mediator.Send(
        //    new GetDepartmentsQuery()));
    }

    [HttpGet("services")]
    public async Task<IActionResult> GetServices(
        [FromQuery] int kioskId,
        [FromQuery] int? departmentId)
    {
        return Ok(await _mediator.Send(
            new GetServicesQuery(kioskId, departmentId)));
    }
}
