namespace CloudSalesSystem.Domain.Customers.Events;

public sealed record CustomerCreatedDomainEvent(Guid CustomerId) : IDomainEvent;