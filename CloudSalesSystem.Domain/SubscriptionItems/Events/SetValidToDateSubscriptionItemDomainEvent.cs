namespace CloudSalesSystem.Domain.SubscriptionItems.Events;

public sealed record SetValidToDateSubscriptionItemDomainEvent(Guid SubscriptionItemId, DateOnly ValidToDate) : IDomainEvent;