namespace CloudSalesSystem.Application.SubscriptionItems.UpdateQuantity;

public sealed record UpdateSubscriptionItemQuantityCommand(
    Guid SubscriptionItemId,
    int Quantity) : IRequest<UpdateSubscriptionItemQuantityResponse>;