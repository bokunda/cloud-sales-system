namespace CloudSalesSystem.Application.Licenses;

public static class LicenseQueryableExtensions
{
    public static IQueryable<License> QueryBySubscriptionId(this IQueryable<License> query, Guid? subscriptionId) =>
        subscriptionId.HasValue
            ? query.Where(l => l.SubscriptionItem.SubscriptionId == subscriptionId)
            : query;

    public static IQueryable<License> QueryByNoAccountId(this IQueryable<License> query) =>
        query.Where(l => l.AccountId == null);

    public static IQueryable<License> QueryByHasAccountId(this IQueryable<License> query) =>
        query.Where(l => l.AccountId != null);

    public static IQueryable<License> QueryByActive(this IQueryable<License> query) =>
        query.Where(l => l.SubscriptionItem.ValidToDate > DateOnly.FromDateTime(DateTime.UtcNow));

    public static IQueryable<License> QueryBySubscriptionItemId(this IQueryable<License> query, Guid? subscriptionItemId) =>
        subscriptionItemId.HasValue
            ? query.Where(l => l.SubscriptionItemId == subscriptionItemId)
            : query;
}