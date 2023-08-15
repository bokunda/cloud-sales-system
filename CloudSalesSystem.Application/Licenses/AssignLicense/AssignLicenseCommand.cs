namespace CloudSalesSystem.Application.Licenses.AssignLicense;

public sealed record AssignLicenseCommand(
    Guid AccountId,
    Guid SubscriptionItemId) : IRequest<AssignLicenseResponse>;