namespace CloudSalesSystem.Domain.SubscriptionItems.Events;

public sealed record CreateSubscriptionItemDomainEvent(Guid SubscriptionItemId) : IDomainEvent;