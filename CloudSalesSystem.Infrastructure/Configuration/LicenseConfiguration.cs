namespace CloudSalesSystem.Infrastructure.Configuration;

internal sealed class LicenseConfiguration : IEntityTypeConfiguration<License>
{
    public void Configure(EntityTypeBuilder<License> builder)
    {
        builder.ToTable("licenses");

        builder.HasKey(license => license.Id);

        builder.Property(license => license.SubscriptionItemId).IsRequired();
        builder.Property(license => license.AccountId).IsRequired();

        builder.HasOne(license => license.SubscriptionItem)
            .WithMany(subscriptionItem => subscriptionItem.Licenses)
            .HasForeignKey(license => license.SubscriptionItemId);

        builder.HasOne(license => license.Account)
            .WithMany(account => account.Licenses)
            .HasForeignKey(license => license.AccountId);
    }
}