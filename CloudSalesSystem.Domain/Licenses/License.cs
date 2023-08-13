namespace CloudSalesSystem.Domain.Licenses;

public sealed class License : Entity<Guid>
{
    private License(
        Guid id,
        Guid? accountId,
        Guid subscriptionItemId)
        : base(id)
    {
        AccountId = accountId;
        SubscriptionItemId = subscriptionItemId;
    }

    public Guid? AccountId { get; private set; }
    public Account Account = null!;
    public Guid SubscriptionItemId { get; private set; }
    public SubscriptionItem SubscriptionItem = null!;

    public static License Create(Guid? accountId, Guid subscriptionItemId)
    {
        var license = new License(Guid.NewGuid(), accountId, subscriptionItemId);
        license.RaiseDomainEvent(new CreateLicenseDomainEvent(license.Id));
        return license;
    }
}