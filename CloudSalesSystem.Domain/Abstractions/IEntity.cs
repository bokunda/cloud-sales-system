namespace CloudSalesSystem.Domain.Abstractions;

public interface IEntity
{
    void SetIsDeleted(bool isDeleted = true);
    IReadOnlyList<IDomainEvent> GetDomainEvents();
    void ClearDomainEvents();
}