namespace CloudSalesSystem.Application.CloudServices.GetCloudServices;

internal sealed class GetCloudServicesQueryHandler : IRequestHandler<GetCloudServicesQuery, IReadOnlyCollection<AvailableServiceItem>>
{
    private readonly ICloudComputingService _cloudComputingService;
    private readonly IMapper _mapper;

    public GetCloudServicesQueryHandler(ICloudComputingService cloudComputingService, 
        IMapper mapper)
    {
        _cloudComputingService = cloudComputingService;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<AvailableServiceItem>> Handle(GetCloudServicesQuery request, CancellationToken cancellationToken)
    {
        var availableServices = await _cloudComputingService.GetAvailableServices(cancellationToken);
        return _mapper.Map<IReadOnlyCollection<AvailableServiceItem>>(availableServices);
    }
}