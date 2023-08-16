namespace CloudSalesSystem.Application.Licenses.AssignLicense;

public class AssignLicenseCommandValidator : AbstractValidator<AssignLicenseCommand>
{
    public AssignLicenseCommandValidator()
    {
        RuleFor(x => x.AccountId).NotEmpty();
        RuleFor(x => x.SubscriptionItemId).NotEmpty();
    }
}