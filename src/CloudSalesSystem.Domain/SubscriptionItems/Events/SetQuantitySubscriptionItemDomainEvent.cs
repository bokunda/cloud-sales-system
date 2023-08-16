namespace CloudSalesSystem.Domain.SubscriptionItems.Events;

public sealed record SetQuantitySubscriptionItemDomainEvent(Guid SubscriptionItemId, int Quantity) : IDomainEvent;