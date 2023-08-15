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

    [HttpPost("order-service-license")]
    public async Task<IActionResult> OrderServiceLicense([FromBody] AssignLicenseCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost("revoke-service-license")]
    public async Task<IActionResult> RevokeServiceLicense([FromBody] RevokeServiceLicenseCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }
}