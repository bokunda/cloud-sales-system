namespace CloudSalesSystem.Domain.Licenses.Events;

public sealed record CreateLicenseDomainEvent(Guid LicenseId) : IDomainEvent;