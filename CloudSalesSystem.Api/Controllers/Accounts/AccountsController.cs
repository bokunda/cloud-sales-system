namespace CloudSalesSystem.Api.Controllers.Accounts;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly ISender _sender;

    public AccountsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAccounts([FromQuery] GetAccountsQuery request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request, cancellationToken);
        return Ok(result);
    }
}