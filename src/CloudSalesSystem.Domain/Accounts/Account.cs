namespace CloudSalesSystem.Domain.Accounts;

public sealed class Account : Entity<Guid>
{
    public static Guid FirstSystemAccountId = new("E0000B5B-7AD0-4B27-8457-47262FDCF1C7");
    public static Guid SecondSystemAccountId = new("E1000B5B-7AD0-4B27-8457-47262FDCF1C7");
    public static Guid ThirdSystemAccountId = new("E2000B5B-7AD0-4B27-8457-47262FDCF1C7");

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
    public Customer Customer { get; private set; } = null!;
    public ICollection<License> Licenses { get; } = new List<License>();


    public static Account Create(string name, string? description, Guid customerId)
    {
        var account = new Account(SequentialGuidGenerator.Generate(), name, description, customerId);
        account.RaiseDomainEvent(new AccountCreatedDomainEvent(account.Id));
        return account;
    }
}