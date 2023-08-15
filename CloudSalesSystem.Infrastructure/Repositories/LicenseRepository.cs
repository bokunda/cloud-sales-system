namespace CloudSalesSystem.Infrastructure.Repositories;

public class LicenseRepository : Repository<License, Guid>, ILicenseRepository
{
    public LicenseRepository(CloudSalesSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ICollection<License>> GetRevokedLicenses(Guid? subscriptionId, Guid? subscriptionItemId, CancellationToken cancellationToken = default) =>
        await DbContext
            .Set<License>()
            .QueryByNoAccountId()
            .QueryBySubscriptionId(subscriptionId)
            .QueryBySubscriptionItemId(subscriptionItemId)
            .QueryByActive()
            .ToListAsync(cancellationToken);

    public async Task<int> GetAssignedLicensesCount(Guid? subscriptionId, Guid? subscriptionItemId, CancellationToken cancellationToken = default) =>
        await DbContext
            .Set<License>()
            .QueryBySubscriptionId(subscriptionId)
            .QueryBySubscriptionItemId(subscriptionItemId)
            .QueryByHasAccountId()
            .QueryByActive()
            .CountAsync(cancellationToken);
}