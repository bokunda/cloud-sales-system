namespace CloudSalesSystem.Application.CloudServices.OrderLicense;

internal sealed class OrderLicenseCommandHandler : IRequestHandler<OrderLicenseCommand, OrderLicenseResponse>
{
    private readonly ICloudComputingService _cloudComputingService;
    private readonly IRepository<SubscriptionItem, Guid> _subscriptionItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderLicenseCommandHandler(
        ICloudComputingService cloudComputingService,
        IRepository<SubscriptionItem, Guid> subscriptionItemRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _cloudComputingService = cloudComputingService;
        _subscriptionItemRepository = subscriptionItemRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OrderLicenseResponse> Handle(OrderLicenseCommand request, CancellationToken cancellationToken)
    {
        // Get service details
        var serviceDetails = await _cloudComputingService.GetServiceDetails(request.ServiceId, cancellationToken);

        // Order service license
        var result = await _cloudComputingService.OrderComputingServiceItem(
            new OrderServiceItemRequest(request.ServiceId, request.Amount, request.ValidToDate),
            cancellationToken);

        // Create db entity
        var subscriptionItem = SubscriptionItem.Create(
            request.SubscriptionId,
            request.ServiceId,
            serviceDetails.Name,
            request.Amount,
            request.ValidToDate);

        _subscriptionItemRepository.Add(subscriptionItem);

        var mappedResponse = _mapper.Map<OrderLicenseResponse>(result);
        mappedResponse.ServiceName = serviceDetails.Name;
        mappedResponse.SubscriptionItemId = subscriptionItem.Id;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return mappedResponse;
    }
}