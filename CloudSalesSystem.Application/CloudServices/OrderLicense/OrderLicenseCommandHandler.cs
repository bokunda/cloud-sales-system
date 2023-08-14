using AutoMapper;
using CloudSalesSystem.Application.Abstractions.CloudServices;

namespace CloudSalesSystem.Application.CloudServices.OrderLicense;

internal sealed class OrderLicenseCommandHandler : IRequestHandler<OrderLicenseCommand, OrderLicenseResponse>
{
    private readonly ICloudComputingService _cloudComputingService;
    private readonly IMapper _mapper;

    public OrderLicenseCommandHandler(
        ICloudComputingService cloudComputingService,
        IMapper mapper)
    {
        _cloudComputingService = cloudComputingService;
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

        // TODO: Store transaction in db
        // TODO: Use auto-mapper

        var mappedResponse = new OrderLicenseResponse(
            result.TransactionId,
            result.TransactionDateTime,
            result.ServiceId,
            serviceDetails.Name,
            result.TotalItems,
            result.PricePerItem,
            result.TotalPrice,
            result.ValidToDate);

        return mappedResponse;
    }
}