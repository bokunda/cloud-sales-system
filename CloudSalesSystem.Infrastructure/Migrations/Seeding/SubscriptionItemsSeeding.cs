namespace CloudSalesSystem.Infrastructure.Migrations.Seeding;

internal class SubscriptionItemsSeeding : ISeeding
{
    public void Seed(ModelBuilder modelBuilder)
    {
        var firstSubscriptionItem = SubscriptionItem.Create(
            Subscription.FirstSubscriptionId, 
            new ("E913C473-25A3-49AA-A80E-D62DA922CA5E"),
            "Service_1",
            7,
            DateOnly.Parse("2025-01-01"));
        firstSubscriptionItem.SetProperty(nameof(SubscriptionItem.Id), Subscription.FirstSubscriptionId);

        var secondSubscriptionItem = SubscriptionItem.Create(
            Subscription.FirstSubscriptionId,
            new("EA13C473-25A3-49AA-A80E-D62DA922CA5E"),
            "Service_2",
            26,
            DateOnly.Parse("2025-09-01"));
        secondSubscriptionItem.SetProperty(nameof(SubscriptionItem.Id), Subscription.SecondSubscriptionId);

        var thirdSubscriptionItem = SubscriptionItem.Create(
            Subscription.FirstSubscriptionId,
            new("EB13C473-25A3-49AA-A80E-D62DA922CA5E"),
            "Service_3",
            19,
            DateOnly.Parse("2025-05-01"));
        thirdSubscriptionItem.SetProperty(nameof(SubscriptionItem.Id), Subscription.ThirdSubscriptionId);

        modelBuilder.Entity<SubscriptionItem>()
            .HasData(new List<SubscriptionItem>
            {
                firstSubscriptionItem, 
                secondSubscriptionItem, 
                thirdSubscriptionItem
            });
    }
}