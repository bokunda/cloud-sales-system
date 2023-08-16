namespace CloudSalesSystem.Api.Controllers.CloudServices;

[Route("api/[controller]")]
[ApiController]
public class CloudServicesController : ControllerBase
{
    private readonly ISender _sender;

    public CloudServicesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Returns available services from Cloud Computing Provider
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetServices(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCloudServicesQuery(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Order requested licenses from Cloud Computing Provider
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("order-service-license")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> OrderServiceLicense([FromBody] OrderLicenseCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }
}