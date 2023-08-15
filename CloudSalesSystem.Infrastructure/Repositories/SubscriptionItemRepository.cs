namespace CloudSalesSystem.Infrastructure.Repositories;

public class SubscriptionItemRepository : Repository<SubscriptionItem, Guid>, ISubscriptionItemRepository
{
    public SubscriptionItemRepository(CloudSalesSystemDbContext dbContext) : base(dbContext)
    {
    }
}