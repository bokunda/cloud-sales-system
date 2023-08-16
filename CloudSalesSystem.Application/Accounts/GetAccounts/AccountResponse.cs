namespace CloudSalesSystem.Application.Accounts.GetAccounts;

public sealed record AccountResponse(Guid Id, string Name, string Description, Guid CustomerId, string CustomerName);