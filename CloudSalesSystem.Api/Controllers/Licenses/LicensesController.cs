namespace CloudSalesSystem.Api.Controllers.Licenses;

[Route("api/[controller]")]
[ApiController]
public class LicensesController : ControllerBase
{
    private readonly ISender _sender;

    public LicensesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> OrderServiceLicense([FromBody] AssignLicenseCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }
}