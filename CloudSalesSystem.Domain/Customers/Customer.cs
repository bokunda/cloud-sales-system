namespace CloudSalesSystem.Domain.Customers;

public sealed class Customer : Entity<Guid>
{
    private Customer(
        Guid id,
        string name,
        string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }

    public ICollection<CustomerSubscription> CustomerSubscriptions { get; } = new List<CustomerSubscription>();
    public ICollection<Account> Accounts { get; } = new List<Account>();

    public static Customer Create(string name, string description)
    {
        var customer = new Customer(SequentialGuidGenerator.Generate(), name, description);
        customer.RaiseDomainEvent(new CustomerCreatedDomainEvent(customer.Id));
        return customer;
    }
}