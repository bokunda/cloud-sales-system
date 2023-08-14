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

    [HttpGet]
    public async Task<IActionResult> GetServices(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetCloudServicesQuery(), cancellationToken);
        return Ok(result);
    }
}