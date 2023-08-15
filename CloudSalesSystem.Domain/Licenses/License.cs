namespace CloudSalesSystem.Domain.Licenses;

public sealed class License : Entity<Guid>
{
    private License(
        Guid id,
        Guid? accountId,
        Guid subscriptionItemId,
        string? key)
        : base(id)
    {
        AccountId = accountId;
        SubscriptionItemId = subscriptionItemId;
        Key = key;
    }

    public Guid? AccountId { get; private set; }
    public Account Account { get; private set; } = null!;
    public Guid SubscriptionItemId { get; private set; }
    public SubscriptionItem SubscriptionItem { get; private set; } = null!;
    public string? Key { get; private set; }

    public static License Create(Guid? accountId, Guid subscriptionItemId, string? key)
    {
        var license = new License(SequentialGuidGenerator.Generate(), accountId, subscriptionItemId, key);
        license.RaiseDomainEvent(new CreateLicenseDomainEvent(license.Id));
        return license;
    }

    public void AssignAccount(Guid accountId)
    {
        AccountId = accountId;
        RaiseDomainEvent(new AssignAccountToLicenseDomainEvent(Id, accountId));
    }

    public void RemoveAccount()
    {
        AccountId = null;
        RaiseDomainEvent(new RemoveAccountFromLicenseEvent(Id));
    }
}