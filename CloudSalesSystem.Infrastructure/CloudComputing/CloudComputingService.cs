namespace CloudSalesSystem.Infrastructure.CloudComputing;

public class CloudComputingService : ICloudComputingService
{
    private readonly CloudComputingHttpClient _cloudComputingHttpClient;

    private const string BaseUrl = "https://api.cloudcomputingprovider/services";

    public CloudComputingService(CloudComputingHttpClient cloudComputingHttpClient)
    {
        _cloudComputingHttpClient = cloudComputingHttpClient;
    }

    public async Task<IReadOnlyCollection<AvailableServiceItem>> GetAvailableServices(CancellationToken cancellationToken)
    {
        var response = await _cloudComputingHttpClient.GetHttpClientMock()
            .GetAsync($"{BaseUrl}/get-all", cancellationToken);

        var data = await response.Content
            .ReadFromJsonAsync<IReadOnlyCollection<AvailableServiceItem>>(cancellationToken: cancellationToken)
            ?? new List<AvailableServiceItem>();

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