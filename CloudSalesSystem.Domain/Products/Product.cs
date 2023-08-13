using CloudSalesSystem.Domain.Products.Events;

namespace CloudSalesSystem.Domain.Products;

public sealed class Product : Entity<Guid>
{
    private Product(
        Guid id,
        string name,
        string? description,
        string provider)
            : base(id)
    {
        Name = name;
        Description = description;
        Provider = provider;
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string Provider { get; private set; }

    public ICollection<SubscriptionItem> SubscriptionItems { get; } = new List<SubscriptionItem>();

    public static Product Create(string name, string? description, string provider)
    {
        var product = new Product(Guid.NewGuid(), name, description, provider);
        product.RaiseDomainEvent(new CreateProductDomainEvent(product.Id));
        return product;
    }
}