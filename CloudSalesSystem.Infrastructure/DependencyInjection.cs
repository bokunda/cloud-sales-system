namespace CloudSalesSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<ICloudComputingService, CloudComputingService>();
        services.AddTransient<CloudComputingHttpClient>();

        AddPersistence(services, configuration);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<CloudSalesSystemDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.AddScoped<ISubscriptionItemRepository, SubscriptionItemRepository>();
        services.AddScoped<ILicenseRepository, LicenseRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CloudSalesSystemDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
    }
}