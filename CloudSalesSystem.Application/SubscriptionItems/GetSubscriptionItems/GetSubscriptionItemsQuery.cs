namespace CloudSalesSystem.Application.SubscriptionItems.GetSubscriptionItems;

public sealed record GetSubscriptionItemsQuery(
    Guid? SubscriptionId,
    Guid? AccountId) : PagedRequest<GetSubscriptionItemsResponse>;