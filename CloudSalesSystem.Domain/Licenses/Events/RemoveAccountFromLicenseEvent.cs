namespace CloudSalesSystem.Domain.Licenses.Events;

public sealed record RemoveAccountFromLicenseEvent(Guid AccountId) : IDomainEvent;