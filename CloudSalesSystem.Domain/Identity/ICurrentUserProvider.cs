namespace CloudSalesSystem.Domain.Identity;

public interface ICurrentUserProvider
{
    Guid CustomerId { get; }
}