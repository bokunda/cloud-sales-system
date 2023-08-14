namespace CloudSalesSystem.Api.Controllers.Accounts;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly ICloudComputingService _cloudComputingService;

    public AccountsController(ISender sender, ICloudComputingService cloudComputingService)
    {
        _sender = sender;
        _cloudComputingService = cloudComputingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAccounts([FromQuery] GetAccountsQuery request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }
}