namespace CloudSalesSystem.Domain.Licenses;

public sealed class License : Entity<Guid>
{
    public static Guid FirstSystemLicenseId = new("426A397F-4D49-4D8C-B775-2EF6DF1D9B61");
    public static Guid SecondSystemLicenseId = new("436A397F-4D49-4D8C-B775-2EF6DF1D9B61");
    public static Guid ThirdSystemLicenseId = new("446A397F-4D49-4D8C-B775-2EF6DF1D9B61");

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
        license.RaiseDomainEvent(new CreateLicenseDomainDomainEvent(license.Id));
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
        RaiseDomainEvent(new RemoveAccountFromLicenseDomainEvent(Id));
    }
}