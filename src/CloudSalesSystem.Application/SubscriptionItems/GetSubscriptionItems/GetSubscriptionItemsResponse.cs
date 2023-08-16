namespace CloudSalesSystem.Application.SubscriptionItems.GetSubscriptionItems;

public sealed record GetSubscriptionItemsResponse(
    Guid Id,
    Guid SubscriptionId, 
    Guid ProductId, 
    int Quantity, 
    int State, 
    DateTime ValidToDate);