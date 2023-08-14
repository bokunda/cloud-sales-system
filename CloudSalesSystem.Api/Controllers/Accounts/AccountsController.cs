using CloudSalesSystem.Application.Abstractions.CloudComputing;
using CloudSalesSystem.Application.Abstractions.CloudComputing.Models;

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

        var test = await _cloudComputingService.GetAvailableServices(cancellationToken);
        var test2 = await _cloudComputingService.OrderComputingServiceItem(new OrderServiceItemRequest(test.First().Id, 4), cancellationToken);

        return Ok(result);
    }
}