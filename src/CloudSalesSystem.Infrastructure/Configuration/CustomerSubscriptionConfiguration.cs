namespace CloudSalesSystem.Infrastructure.Configuration;

internal sealed class CustomerSubscriptionConfiguration : IEntityTypeConfiguration<CustomerSubscription>
{
    public void Configure(EntityTypeBuilder<CustomerSubscription> builder)
    {
        builder.ToTable("customer_subscriptions");

        builder.HasKey(customerSubscription =>
            new
            {
                customerSubscription.CustomerId, 
                customerSubscription.SubscriptionId
            });
    }
}