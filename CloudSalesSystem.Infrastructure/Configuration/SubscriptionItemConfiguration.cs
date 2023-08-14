namespace CloudSalesSystem.Infrastructure.Configuration;

internal sealed class SubscriptionItemConfiguration : IEntityTypeConfiguration<SubscriptionItem>
{
    public void Configure(EntityTypeBuilder<SubscriptionItem> builder)
    {
        builder.ToTable("subscription_items");

        builder.Property(subscriptionItem => subscriptionItem.SubscriptionId).IsRequired();
        builder.Property(subscriptionItem => subscriptionItem.ProductId).IsRequired();
        builder.Property(subscriptionItem => subscriptionItem.Quantity).IsRequired();
        builder.Property(subscriptionItem => subscriptionItem.State).IsRequired();
        builder.Property(subscriptionItem => subscriptionItem.ValidToDate).IsRequired();

        builder.HasKey(subscriptionItem => subscriptionItem.Id);

        builder.HasMany(subscriptionItem => subscriptionItem.Licenses)
            .WithOne(license => license.SubscriptionItem)
            .HasForeignKey(license => license.SubscriptionItemId);

        builder.HasOne(subscriptionItem => subscriptionItem.Subscription)
            .WithMany(subscription => subscription.SubscriptionItems)
            .HasForeignKey(subscriptionItem => subscriptionItem.SubscriptionId);
    }
}