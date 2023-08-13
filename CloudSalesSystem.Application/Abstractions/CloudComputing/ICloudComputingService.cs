namespace CloudSalesSystem.Application.Abstractions.CloudComputing;

public interface ICloudComputingService
{
    Task<IReadOnlyCollection<AvailableServiceItem>> GetAvailableServices(CancellationToken cancellationToken);
    Task<OrderServiceItemResponse> OrderComputingServiceItem(OrderServiceItemRequest request, CancellationToken cancellationToken);
}