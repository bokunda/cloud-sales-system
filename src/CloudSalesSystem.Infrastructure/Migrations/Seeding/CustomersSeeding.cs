namespace CloudSalesSystem.Infrastructure.Migrations.Seeding;

internal class CustomersSeeding : ISeeding
{
    public void Seed(ModelBuilder modelBuilder)
    {
        var customer = Customer.Create("Customer_Name_1", "Customer_Description_1");
        customer.SetProperty(nameof(Customer.Id), Customer.SystemCustomerId);

        modelBuilder.Entity<Customer>()
            .HasData(customer);
    }
}