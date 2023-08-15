namespace CloudSalesSystem.Domain.Licenses.Events;

public sealed record ValidToDateUpdateLicenseEvent(Guid LicenseId) : IDomainEvent;