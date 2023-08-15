﻿namespace CloudSalesSystem.Domain.Abstractions;

public abstract class Entity<TEntityId> : IEntity, IEntityHasCreatedUpdated
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(TEntityId id)
    {
        Id = id;
    }

    protected Entity() { }

    public TEntityId Id { get; init; }
    public DateTimeOffset CreatedOn { get; private set; }
    public DateTimeOffset UpdatedOn { get; private set; }
    public bool IsDeleted { get; private set; }

    public void SetIsDeleted(bool isDeleted = true) => IsDeleted = isDeleted;
    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    public void ClearDomainEvents() => _domainEvents.Clear();
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void SetCreated(DateTimeOffset createdOn) => CreatedOn = createdOn;
    public void SetUpdated(DateTimeOffset updatedOn) => UpdatedOn = updatedOn;
}