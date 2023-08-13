namespace CloudSalesSystem.Infrastructure.Configuration;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Name).IsRequired();
        builder.Property(product => product.Provider).IsRequired();

        builder.HasMany(product => product.SubscriptionItems)
            .WithOne(subscriptionItem => subscriptionItem.Product)
            .HasForeignKey(subscriptionItem => subscriptionItem.ProductId);
    }
}