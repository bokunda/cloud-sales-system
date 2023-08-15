namespace CloudSalesSystem.Domain.Licenses;

public interface ILicenseRepository : IRepository<License, Guid>
{
    Task<ICollection<License>> GetUnassignedLicenses(CancellationToken cancellationToken = default);
    Task<int> GetAssignedLicensesCount(Guid subscriptionId, CancellationToken cancellationToken = default);
}