namespace CloudSalesSystem.Domain.Licenses.Events;

public sealed record AssignAccountToLicenseDomainEvent(Guid LicenseId, Guid AccountId) : IDomainEvent;