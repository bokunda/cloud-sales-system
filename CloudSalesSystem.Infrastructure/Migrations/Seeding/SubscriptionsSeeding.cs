namespace CloudSalesSystem.Infrastructure.Migrations.Seeding;

internal class SubscriptionsSeeding : ISeeding
{
    public void Seed(ModelBuilder modelBuilder)
    {
        var subscription = Subscription.Create("Subscription_Name_1", "Subscription_Description_1");
        subscription.SetProperty(nameof(Subscription.Id), Subscription.FirstSubscriptionId);

        var customerSubscription = CustomerSubscription.Create(Customer.SystemCustomerId, Subscription.FirstSubscriptionId);

        modelBuilder.Entity<Subscription>()
            .HasData(subscription);

        modelBuilder.Entity<CustomerSubscription>()
            .HasData(customerSubscription);
    }
}