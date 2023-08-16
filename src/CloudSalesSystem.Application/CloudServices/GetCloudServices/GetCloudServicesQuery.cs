namespace CloudSalesSystem.Application.CloudServices.GetCloudServices;

public sealed record GetCloudServicesQuery() : IRequest<IReadOnlyCollection<AvailableServiceItem>>;