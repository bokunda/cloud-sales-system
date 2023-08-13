namespace CloudSalesSystem.Domain.Products.Events;

public sealed record CreateProductDomainEvent(Guid ProductId) : IDomainEvent;