namespace CloudSalesSystem.Application.Accounts.GetAccounts;

public sealed record GetAccountsQuery(Guid CustomerId) : PagedRequest<AccountResponse>;