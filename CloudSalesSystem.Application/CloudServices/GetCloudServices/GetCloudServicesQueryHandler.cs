namespace CloudSalesSystem.Application.CloudServices.GetCloudServices;

internal sealed class GetCloudServicesQueryHandler : IRequestHandler<GetCloudServicesQuery, IReadOnlyCollection<AvailableServiceItem>>
{
    private readonly ICloudComputingService _cloudComputingService;

    public GetCloudServicesQueryHandler(ICloudComputingService cloudComputingService)
    {
        _cloudComputingService = cloudComputingService;
    }

    public async Task<IReadOnlyCollection<AvailableServiceItem>> Handle(GetCloudServicesQuery request, CancellationToken cancellationToken)
    {
        var availableServices = await _cloudComputingService.GetAvailableServices(cancellationToken);
        return availableServices;
    }
}