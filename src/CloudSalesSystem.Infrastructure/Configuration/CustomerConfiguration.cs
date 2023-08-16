namespace CloudSalesSystem.Infrastructure.Configuration;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(customer => customer.Description)
            .HasMaxLength(200);

        builder.HasMany(customer => customer.CustomerSubscriptions)
            .WithOne(customerSubscription => customerSubscription.Customer)
            .HasForeignKey(customerSubscription => customerSubscription.CustomerId);

        builder.HasMany(customer => customer.Accounts)
            .WithOne(account => account.Customer)
            .HasForeignKey(account => account.CustomerId);
    }
}