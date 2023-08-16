namespace CloudSalesSystem.Application.CloudServices.OrderLicense;

public class OrderLicenseCommandValidator : AbstractValidator<OrderLicenseCommand>
{
    public OrderLicenseCommandValidator()
    {
        RuleFor(x => x.ServiceId).NotNull();
        RuleFor(x => x.SubscriptionId).NotNull();
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.ValidToDate)
            .NotNull()
            .GreaterThan(DateOnly.FromDateTime(DateTime.UtcNow));
    }
}