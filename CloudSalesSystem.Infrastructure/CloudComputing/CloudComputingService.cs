using Microsoft.Extensions.Caching.Memory;

namespace CloudSalesSystem.Infrastructure.CloudComputing;

public class CloudComputingService : ICloudComputingService
{
    private readonly CloudComputingHttpClient _cloudComputingHttpClient;
    private readonly IMemoryCache _memoryCache;

    private const string BaseUrl = "https://api.cloudcomputingprovider/services";

    public CloudComputingService(
        CloudComputingHttpClient cloudComputingHttpClient,
        IMemoryCache memoryCache)
    {
        _cloudComputingHttpClient = cloudComputingHttpClient;
        _memoryCache = memoryCache;
    }

    public async Task<IReadOnlyCollection<AvailableServiceItem>> GetAvailableServices(CancellationToken cancellationToken)
    {
        var cacheKey = $"{nameof(CloudComputingService)}:{nameof(GetAvailableServices)}";

        if (_memoryCache.TryGetValue(cacheKey, out IReadOnlyCollection<AvailableServiceItem>? result) && result is not null)
        {
            return result;
        }

        var response = await _cloudComputingHttpClient.GetHttpClientMock()
            .GetAsync($"{BaseUrl}/get-all", cancellationToken);

        var data = await response.Content
            .ReadFromJsonAsync<IReadOnlyCollection<AvailableServiceItem>>(cancellationToken: cancellationToken)
            ?? new List<AvailableServiceItem>();

        _memoryCache.Set(cacheKey, data, TimeSpan.FromDays(1));

        return data;
    }

    public async Task<OrderServiceItemResponse> OrderComputingServiceItem(OrderServiceItemRequest request, CancellationToken cancellationToken)
    {
        var response = await _cloudComputingHttpClient.GetHttpClientMock(request.ServiceId, request.Amount)
            .GetAsync($"{BaseUrl}/order?id={request.ServiceId}&amount={request.Amount}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("OrderComputingServiceItem failed");
        }

        var data = await response.Content.ReadFromJsonAsync<OrderServiceItemResponse>(cancellationToken: cancellationToken);

        return data!;
    }
}