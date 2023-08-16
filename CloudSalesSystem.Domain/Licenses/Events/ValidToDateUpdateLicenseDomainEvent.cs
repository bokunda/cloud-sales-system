namespace CloudSalesSystem.Domain.Licenses.Events;

public sealed record ValidToDateUpdateLicenseDomainEvent(Guid LicenseId) : IDomainEvent;