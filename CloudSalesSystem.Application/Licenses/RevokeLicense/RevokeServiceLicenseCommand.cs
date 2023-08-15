namespace CloudSalesSystem.Application.Licenses.RevokeLicense;

public sealed record RevokeServiceLicenseCommand(Guid LicenseId) : IRequest<RevokeServiceLicenseResponse>;