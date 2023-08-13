using CloudSalesSystem.Domain.CustomerSubscriptions;
using CloudSalesSystem.Domain.Subscriptions.Events;

namespace CloudSalesSystem.Domain.Subscriptions;

public sealed class Subscription : Entity<Guid>
{
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
        var subscription = new Subscription(Guid.NewGuid(), name, description);
        subscription.RaiseDomainEvent(new CreateSubscriptionDomainEvent(subscription.Id));
        return subscription;
    }
}