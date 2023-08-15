namespace CloudSalesSystem.Application.SubscriptionItems.UpdateQuantity;

public class UpdateSubscriptionItemQuantityCommandValidator : AbstractValidator<UpdateSubscriptionItemQuantityCommand>
{
    public UpdateSubscriptionItemQuantityCommandValidator()
    {
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.SubscriptionItemId).NotNull();
    }
}