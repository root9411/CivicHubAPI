using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Application.Features.Kiosks.Commands;
using SharedLibrary.Application.Interface;

[ApiController]
[Route("api/kiosk")]
public class KioskController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IKioskReadRepository _kioskReadRepository;

    public KioskController(IMediator mediator, IKioskReadRepository kioskReadRepository)
    {
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
        var isActive = true;
        return Ok(isActive);
    }


    // GET: api/kiosk/lookup/languages/1
    [HttpGet("languages/{kioskId}")]
    public async Task<IActionResult> GetLanguages(int kioskId)
    {
        return Ok(await _mediator.Send(
            new GetLanguagesQuery(kioskId)));
    }

    // GET: api/kiosk/lookup/departments
    [HttpGet("departments")]
    public async Task<IActionResult> GetDepartments()
    {

        var kiosks = await _kioskReadRepository.GetDepartmentsAsync();
        return Ok();

        //return Ok(await _mediator.Send(
        //    new GetDepartmentsQuery()));
    }

    // GET: api/kiosk/lookup/services?kioskId=1&departmentId=2
    [HttpGet("services")]
    public async Task<IActionResult> GetServices(
        [FromQuery] int kioskId,
        [FromQuery] int? departmentId)
    {
        return Ok(await _mediator.Send(
            new GetServicesQuery(kioskId, departmentId)));
    }
}
