namespace CloudSalesSystem.Domain.CustomerSubscriptions;

public sealed class CustomerSubscription
{
    private CustomerSubscription(
        Guid customerId,
        Guid subscriptionId)
    {
        CustomerId = customerId;
        SubscriptionId = subscriptionId;
    }

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public Guid SubscriptionId { get; private set; }
    public Subscription Subscription { get; private set; }

    public static CustomerSubscription Create(Guid customerId, Guid subscriptionId) => new (customerId, subscriptionId);
}