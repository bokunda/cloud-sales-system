namespace CloudSalesSystem.Domain.Licenses.Events;

public sealed record RemoveAccountFromLicenseDomainEvent(Guid AccountId) : IDomainEvent;