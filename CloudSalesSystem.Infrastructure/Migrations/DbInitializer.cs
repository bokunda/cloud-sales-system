namespace CloudSalesSystem.Infrastructure.Migrations;

public static class DbInitializer
{
    private static readonly IList<ISeeding> SeedingItems = new List<ISeeding>(10);

    static DbInitializer()
    {
        SeedingItems.Add(new CustomersSeeding());
        SeedingItems.Add(new AccountsSeeding());
        SeedingItems.Add(new SubscriptionsSeeding());
        SeedingItems.Add(new SubscriptionItemsSeeding());
        SeedingItems.Add(new LicensesSeeding());
    }

    // EF Core way of seeding data: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
    public static void SeedData(ModelBuilder modelBuilder)
    {
        foreach (var seeding in SeedingItems)
        {
            seeding.Seed(modelBuilder);
        }
    }
}