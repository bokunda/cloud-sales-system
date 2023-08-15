namespace CloudSalesSystem.Application.Licenses;

public static class LicenseQueryableExtensions
{
    public static IQueryable<License> QueryByNoSubscriptionId(this IQueryable<License> query, Guid subscriptionId) =>
        query.Where(l => l.SubscriptionItem.SubscriptionId == subscriptionId);

    public static IQueryable<License> QueryByNoAccountId(this IQueryable<License> query) =>
        query.Where(l => l.AccountId == null);

    public static IQueryable<License> QueryByActive(this IQueryable<License> query) =>
        query.Where(l => l.SubscriptionItem.ValidToDate > DateTime.UtcNow);
}