namespace CloudSalesSystem.Infrastructure.Migrations.Seeding;

internal class LicensesSeeding : ISeeding
{
    public void Seed(ModelBuilder modelBuilder)
    {
        var firstLicense = License.Create(
            Account.FirstSystemAccountId,
            Subscription.FirstSubscriptionId, 
            "D3694155-870D-41BF-BD38-01742D5CDD53");
        firstLicense.SetProperty(nameof(License.Id), License.FirstSystemLicenseId);

        var secondLicense = License.Create(
            Account.FirstSystemAccountId,
            Subscription.FirstSubscriptionId,
            "D4694155-870D-41BF-BD38-01742D5CDD53");
        firstLicense.SetProperty(nameof(License.Id), License.SecondSystemLicenseId);

        var thirdLicense = License.Create(
            Account.SecondSystemAccountId,
            Subscription.FirstSubscriptionId,
            "D5694155-870D-41BF-BD38-01742D5CDD53");
        firstLicense.SetProperty(nameof(License.Id), License.ThirdSystemLicenseId);

        modelBuilder.Entity<License>()
            .HasData(new List<License>
            {
                firstLicense,
                secondLicense,
                thirdLicense
            });
    }
}