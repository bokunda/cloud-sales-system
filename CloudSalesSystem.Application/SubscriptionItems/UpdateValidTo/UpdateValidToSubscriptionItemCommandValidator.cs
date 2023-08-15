namespace CloudSalesSystem.Application.SubscriptionItems.UpdateValidTo;

public class UpdateValidToSubscriptionItemCommandValidator : AbstractValidator<UpdateValidToSubscriptionItemCommand>
{
    public UpdateValidToSubscriptionItemCommandValidator()
    {
        RuleFor(x => x.SubscriptionItemId).NotNull();
        RuleFor(x => x.ValidToDate)
            .NotNull()
            .GreaterThan(DateOnly.FromDateTime(DateTime.UtcNow));
    }
}