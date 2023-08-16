namespace CloudSalesSystem.Api.Health;

public class CloudServiceHealthCheck : IHealthCheck
{
    private readonly ICloudComputingService _cloudComputingService;

    public CloudServiceHealthCheck(ICloudComputingService cloudComputingService)
    {
        _cloudComputingService = cloudComputingService;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            await _cloudComputingService.GetAvailableServices(cancellationToken);
            return HealthCheckResult.Healthy();
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy(exception: exception);
        }
    }
}