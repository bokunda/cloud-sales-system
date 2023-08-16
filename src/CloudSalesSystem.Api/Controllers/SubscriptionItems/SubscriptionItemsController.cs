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

    /// <summary>
    /// Returns subscription items for the given customer and params
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] GetSubscriptionItemsQuery query, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Try to update quantity for subscription items using Cloud Computing Provider
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("update-quantity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateQuantity([FromBody] UpdateSubscriptionItemQuantityCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Extends license validity using Cloud Computing Provider
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("update-valid-to")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateValidToDate([FromBody] UpdateValidToSubscriptionItemCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);
        return Ok(result);
    }
}