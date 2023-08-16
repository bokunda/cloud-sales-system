namespace CloudSalesSystem.Application.CloudServices.GetCloudServices;

public sealed record GetCloudServicesItemResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price);