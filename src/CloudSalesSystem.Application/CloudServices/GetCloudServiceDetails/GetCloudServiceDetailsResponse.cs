namespace CloudSalesSystem.Application.CloudServices.GetCloudServiceDetails;

public sealed record GetCloudServiceDetailsResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price);