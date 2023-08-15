namespace CloudSalesSystem.Infrastructure.Repositories;

public class LicenseRepository : Repository<License, Guid>, ILicenseRepository
{
    public LicenseRepository(CloudSalesSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ICollection<License>> GetUnassignedLicenses(CancellationToken cancellationToken = default) =>
        await DbContext
            .Set<License>()
            .QueryByNoAccountId()
            .QueryByActive()
            .ToListAsync(cancellationToken);

    public async Task<int> GetAssignedLicensesCount(Guid subscriptionId, CancellationToken cancellationToken = default) =>
        await DbContext
            .Set<License>()
            .QueryByNoSubscriptionId(subscriptionId)
            .QueryByActive()
            .CountAsync(cancellationToken);
}