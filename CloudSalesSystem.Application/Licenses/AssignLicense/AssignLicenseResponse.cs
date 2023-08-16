namespace CloudSalesSystem.Application.Licenses.AssignLicense;

public sealed record AssignLicenseResponse(Guid Id, Guid AccountId, Guid SubscriptionItemId, string Key);