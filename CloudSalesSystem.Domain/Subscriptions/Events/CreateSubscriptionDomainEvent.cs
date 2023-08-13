namespace CloudSalesSystem.Domain.Subscriptions.Events;

public sealed record CreateSubscriptionDomainEvent(Guid SubscriptionId) : IDomainEvent;