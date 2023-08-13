namespace CloudSalesSystem.Infrastructure.Configuration;

internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");

        builder.HasKey(account => account.Id);

        builder.Property(account => account.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(account => account.Description)
            .HasMaxLength(200);

        builder.HasMany(account => account.Licenses)
            .WithOne(license => license.Account)
            .HasForeignKey(license => license.AccountId);

        builder.HasOne(account => account.Customer)
            .WithMany(customer => customer.Accounts)
            .HasForeignKey(account => account.CustomerId);
    }
}