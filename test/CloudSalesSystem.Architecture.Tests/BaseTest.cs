namespace CloudSalesSystem.Architecture.Tests;

public class BaseTest
{
    protected static Assembly ApplicationAssembly => typeof(IPagedRequest).Assembly;

    protected static Assembly DomainAssembly => typeof(IEntity).Assembly;

    protected static Assembly InfrastructureAssembly => typeof(CloudSalesSystemDbContext).Assembly;
}