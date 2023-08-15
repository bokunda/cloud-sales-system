namespace CloudSalesSystem.Application.SubscriptionItems.UpdateValidTo;

public sealed record UpdateValidToSubscriptionItemCommand(
    Guid SubscriptionItemId,
    DateOnly ValidToDate) : IRequest<UpdateValidToSubscriptionItemResponse>;