namespace CloudSalesSystem.Application.CloudServices.GetCloudServiceDetails;

public sealed record GetCloudServiceDetailsQuery(Guid ServiceId) : IRequest<GetCloudServiceDetailsResponse>;