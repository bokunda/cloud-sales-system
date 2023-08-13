namespace CloudSalesSystem.Domain.Accounts;

public sealed class Account : Entity<Guid>
{
    private Account(
        Guid id,
        string name,
        string? description,
        Guid customerId)
        : base(id)
    {
        Name = name;
        Description = description;
        CustomerId = customerId;
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public ICollection<License> Licenses { get; } = new List<License>();


    public static Account Create(string name, string? description, Guid customerId)
    {
        var account = new Account(Guid.NewGuid(), name, description, customerId);
        account.RaiseDomainEvent(new AccountCreatedDomainEvent(account.Id));
        return account;
    }
}