namespace CloudSalesSystem.Application.CloudServices.GetCloudServiceDetails;

internal sealed class GetCloudServiceDetailsQueryHandler : IRequestHandler<GetCloudServiceDetailsQuery, GetCloudServiceDetailsResponse>
{
    private readonly ICloudComputingService _cloudComputingService;
    private readonly IMapper _mapper;

    public GetCloudServiceDetailsQueryHandler(ICloudComputingService cloudComputingService, IMapper mapper)
    {
        _cloudComputingService = cloudComputingService;
        _mapper = mapper;
    }

    public async Task<GetCloudServiceDetailsResponse> Handle(GetCloudServiceDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _cloudComputingService.GetServiceDetails(request.ServiceId, cancellationToken);
        return _mapper.Map<GetCloudServiceDetailsResponse>(result);
    }
}
