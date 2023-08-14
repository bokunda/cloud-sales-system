namespace CloudSalesSystem.Application.CloudServices.OrderLicense;

public sealed record OrderLicenseCommand(
    Guid SubscriptionId,
    Guid ServiceId,
    int Amount,
    DateTime ValidToDate) : IRequest<OrderLicenseResponse>;