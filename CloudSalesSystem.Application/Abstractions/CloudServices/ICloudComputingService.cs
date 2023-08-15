namespace CloudSalesSystem.Application.Abstractions.CloudServices;

public interface ICloudComputingService
{
    Task<IReadOnlyCollection<AvailableServiceItem>> GetAvailableServices(CancellationToken cancellationToken = default);
    Task<AvailableServiceItem> GetServiceDetails(Guid serviceId, CancellationToken cancellationToken = default);
    Task<OrderServiceItemResponse> OrderComputingServiceItem(OrderServiceItemRequest request, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<ServiceItemLicenseKeyResponse>> GetServiceItemLicenseKeys(ServiceItemLicenseKeyRequest request, CancellationToken cancellationToken = default);
    Task<bool> RevokeLicenseKeys(IReadOnlyCollection<RevokeServiceItemLicenseKeyRequest> request, CancellationToken cancellationToken = default);
    Task<bool> ExtendLicenseKeys(IReadOnlyCollection<ExtendServiceItemLicenseKeyRequest> request, CancellationToken cancellationToken = default);
}