using CloudSalesSystem.Application.Accounts.GetAccounts;
using MediatR;

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
    public async Task<IActionResult> GetAccounts(Guid customerId, CancellationToken cancellationToken)
    {
        var query = new GetAccountsQuery(customerId);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }
}