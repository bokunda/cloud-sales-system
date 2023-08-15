namespace CloudSalesSystem.Application.CloudServices.OrderLicense;

public sealed record OrderLicenseCommand(
    Guid SubscriptionId,
    Guid ServiceId,
    int Amount,
    DateOnly ValidToDate) : IRequest<OrderLicenseResponse>;