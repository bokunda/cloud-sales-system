namespace CloudSalesSystem.Domain.SubscriptionItems;

public sealed class SubscriptionItem : Entity<Guid>
{
    private SubscriptionItem(
        Guid id,
        Guid subscriptionId,
        Guid productId,
        string productName,
        int quantity,
        SubscriptionItemState state,
        DateTime validToDate)
        : base(id)
    {
        SubscriptionId = subscriptionId;
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        State = state;
        ValidToDate = validToDate;
    }

    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public SubscriptionItemState State { get; private set; }
    public DateTime ValidToDate { get; private set; }
    public Guid SubscriptionId { get; private set; }
    public Subscription Subscription { get; private set; } = null!;

    public ICollection<License> Licenses { get; } = new List<License>();

    public static SubscriptionItem Create(Guid subscriptionId, Guid productId, string productName, int quantity, DateTime validToDate)
    {
        var subscriptionItem = new SubscriptionItem(
            SequentialGuidGenerator.Generate(),
            subscriptionId,
            productId,
            productName,
            quantity,
            SubscriptionItemState.Active,
            validToDate);
        subscriptionItem.RaiseDomainEvent(new CreateSubscriptionItemDomainEvent(subscriptionItem.Id));
        return subscriptionItem;
    }
}