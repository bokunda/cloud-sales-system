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

    /// <summary>
    /// Tries to assign license to an account
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("assign-license")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AssignLicense([FromBody] AssignLicenseCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Tries to revoke assigned license from account
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("revoke-service-license")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RevokeServiceLicense([FromBody] RevokeServiceLicenseCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }
}