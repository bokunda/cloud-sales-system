namespace CloudSalesSystem.Domain.Accounts.Events;

public sealed record AccountCreatedDomainEvent(Guid AccountId) : IDomainEvent;