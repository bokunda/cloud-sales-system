namespace CloudSalesSystem.Application.Licenses.RevokeLicense;

public class RevokeServiceLicenseCommandValidator : AbstractValidator<RevokeServiceLicenseCommand>
{
    public RevokeServiceLicenseCommandValidator()
    {
        RuleFor(x => x.LicenseId).NotNull();
    }
}