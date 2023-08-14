namespace CloudSalesSystem.Application.SubscriptionItems.GetSubscriptionItems;

public sealed record GetSubscriptionItemsQuery(
    Guid? SubscriptionId,
    Guid? CustomerId,
    Guid? AccountId) : PagedRequest<GetSubscriptionItemsResponse>;