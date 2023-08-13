using CloudSalesSystem.Domain.Products;
using CloudSalesSystem.Domain.SubscriptionItems.Events;

namespace CloudSalesSystem.Domain.SubscriptionItems;

public sealed class SubscriptionItem : Entity<Guid>
{
    private SubscriptionItem(
        Guid id,
        Guid subscriptionId,
        Guid productId,
        int quantity,
        SubscriptionItemState state,
        DateTime validToDate)
    {
        
    }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public SubscriptionItemState State { get; private set; }
    public DateTime ValidToDate { get; private set; }
    public Guid SubscriptionId { get; private set; }
    public Subscription Subscription { get; private set; }

    public ICollection<License> Licenses { get; } = new List<License>();

    public static SubscriptionItem Create(Guid subscriptionId, Guid productId, int quantity, DateTime validToDate)
    {
        var subscriptionItem = new SubscriptionItem(
            Guid.NewGuid(),
            subscriptionId,
            productId,
            quantity,
            SubscriptionItemState.Active,
            validToDate);
        subscriptionItem.RaiseDomainEvent(new CreateSubscriptionItemDomainEvent(subscriptionItem.Id));
        return subscriptionItem;
    }
}