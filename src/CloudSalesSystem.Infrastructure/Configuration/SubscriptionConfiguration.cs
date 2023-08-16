namespace CloudSalesSystem.Infrastructure.Configuration;

internal sealed class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("subscriptions");

        builder.HasKey(subscription => subscription.Id);

        builder.HasMany(subscription => subscription.SubscriptionItems)
            .WithOne(subscriptionItem => subscriptionItem.Subscription)
            .HasForeignKey(subscriptionItem => subscriptionItem.SubscriptionId);

        builder.HasMany(subscription => subscription.CustomerSubscriptions)
            .WithOne(customerSubscription => customerSubscription.Subscription)
            .HasForeignKey(customerSubscription => customerSubscription.SubscriptionId);
    }
}