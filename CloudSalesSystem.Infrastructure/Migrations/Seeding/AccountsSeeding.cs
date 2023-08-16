namespace CloudSalesSystem.Infrastructure.Migrations.Seeding;

internal class AccountsSeeding : ISeeding
{
    public void Seed(ModelBuilder modelBuilder)
    {
        var firstAccount = Account.Create("Account_Name_1", "Account_Description_1", Customer.SystemCustomerId);
        firstAccount.SetProperty(nameof(Account.Id), Account.FirstSystemAccountId);

        var secondAccount = Account.Create("Account_Name_2", "Account_Description_2", Customer.SystemCustomerId);
        secondAccount.SetProperty(nameof(Account.Id), Account.SecondSystemAccountId);

        var thirdAccount = Account.Create("Account_Name_3", "Account_Description_3", Customer.SystemCustomerId);
        thirdAccount.SetProperty(nameof(Account.Id), Account.ThirdSystemAccountId);

        modelBuilder.Entity<Account>()
            .HasData(new List<Account>
            {
                firstAccount,
                secondAccount,
                thirdAccount
            });
    }
}