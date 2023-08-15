namespace CloudSalesSystem.Domain.Licenses;

public interface ILicenseRepository : IRepository<License, Guid>
{
    Task<ICollection<License>> GetRevokedLicenses(Guid? subscriptionId, Guid? subscriptionItemId, CancellationToken cancellationToken = default);
    Task<ICollection<License>> GetAssignedLicenses(Guid? subscriptionId, Guid? subscriptionItemId, CancellationToken cancellationToken = default);
    Task<int> GetAssignedLicensesCount(Guid? subscriptionId, Guid? subscriptionItemId, CancellationToken cancellationToken = default);
}