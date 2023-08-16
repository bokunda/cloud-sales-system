namespace CloudSalesSystem.Api.Tests;

public abstract class BaseApiTests : IClassFixture<ApiTestWebAppFactory>
{
    protected readonly ISender Sender;
    protected readonly CloudSalesSystemDbContext DbContext;

    protected BaseApiTests(ApiTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();

        Sender = scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = scope.ServiceProvider.GetRequiredService<CloudSalesSystemDbContext>();
    }
}