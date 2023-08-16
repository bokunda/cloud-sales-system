namespace CloudSalesSystem.Domain.SubscriptionItems;

public sealed class SubscriptionItem : Entity<Guid>
{
    public static Guid FirstSubscriptionItemId = new("74E083D4-13AE-4AFC-8040-62D226357C56");
    public static Guid SecondSubscriptionItemId = new("75E083D4-13AE-4AFC-8040-62D226357C56");
    public static Guid ThirdSubscriptionItemId = new("76E083D4-13AE-4AFC-8040-62D226357C56");

    private SubscriptionItem(
        Guid id,
        Guid subscriptionId,
        Guid productId,
        string productName,
        int quantity,
        SubscriptionItemState state,
        DateOnly validToDate)
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
    public DateOnly ValidToDate { get; private set; }
    public Guid SubscriptionId { get; private set; }
    public Subscription Subscription { get; private set; } = null!;

    public ICollection<License> Licenses { get; } = new List<License>();

    public static SubscriptionItem Create(Guid subscriptionId, Guid productId, string productName, int quantity, DateOnly validToDate)
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

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
        RaiseDomainEvent(new SetQuantitySubscriptionItemDomainEvent(Id, Quantity));
    }

    public void SetValidTo(DateOnly validToDate)
    {
        ValidToDate = validToDate;
        RaiseDomainEvent(new SetValidToDateSubscriptionItemDomainEvent(Id, ValidToDate));
    }
}