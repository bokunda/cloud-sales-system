namespace CloudSalesSystem.Infrastructure.Identity;

public class CurrentUserProvider : ICurrentUserProvider
{
    public Guid CustomerId { get; } = Guid.NewGuid();
}