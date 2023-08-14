namespace CloudSalesSystem.Application.Abstractions.CloudServices;

public interface ICloudComputingService
{
    Task<IReadOnlyCollection<AvailableServiceItem>> GetAvailableServices(CancellationToken cancellationToken);
    Task<OrderServiceItemResponse> OrderComputingServiceItem(OrderServiceItemRequest request, CancellationToken cancellationToken);
}