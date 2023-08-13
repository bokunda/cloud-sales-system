namespace CloudSalesSystem.Application.Accounts.GetAccounts;

// public sealed record GetAccountsQuery(Guid CustomerId) : IRequest<IReadOnlyList<AccountResponse>>, IRequest<AccountResponse>;
public sealed record GetAccountsQuery(Guid CustomerId) : PagedRequest<AccountResponse>;