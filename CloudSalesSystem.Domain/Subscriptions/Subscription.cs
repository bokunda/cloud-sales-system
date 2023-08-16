namespace CloudSalesSystem.Domain.Subscriptions;

public sealed class Subscription : Entity<Guid>
{
    public static Guid FirstSubscriptionId = new("74E083D4-13AE-4AFC-8040-62D226357C56");
    public static Guid SecondSubscriptionId = new("75E083D4-13AE-4AFC-8040-62D226357C56");
    public static Guid ThirdSubscriptionId = new("76E083D4-13AE-4AFC-8040-62D226357C56");

    private Subscription(
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
    public ICollection<SubscriptionItem> SubscriptionItems { get; } = new List<SubscriptionItem>();

    public static Subscription Create(string name, string description)
    {
        var subscription = new Subscription(SequentialGuidGenerator.Generate(), name, description);
        subscription.RaiseDomainEvent(new CreateSubscriptionDomainEvent(subscription.Id));
        return subscription;
    }
}