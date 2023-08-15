using CloudSalesSystem.Application.SubscriptionItems.GetSubscriptionItems;
using CloudSalesSystem.Application.SubscriptionItems.UpdateQuantity;
using CloudSalesSystem.Application.SubscriptionItems.UpdateValidTo;

namespace CloudSalesSystem.Api.Controllers.SubscriptionItems;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionItemsController : ControllerBase
{
    private readonly ISender _sender;

    public SubscriptionItemsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetSubscriptionItemsQuery query, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost("update-quantity")]
    public async Task<IActionResult> UpdateQuantity([FromBody] UpdateSubscriptionItemQuantityCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("update-valid-to")]
    public async Task<IActionResult> UpdateValidToDate([FromBody] UpdateValidToSubscriptionItemCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }
}