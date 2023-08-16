namespace CloudSalesSystem.Domain.Licenses.Events;

public sealed record CreateLicenseDomainDomainEvent(Guid LicenseId) : IDomainEvent;