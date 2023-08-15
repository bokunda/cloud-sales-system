namespace CloudSalesSystem.Application.Licenses.AssignLicense;

public sealed record AssignLicenseResponse(Guid AccountId, Guid SubscriptionItemId, string LicenseKey);