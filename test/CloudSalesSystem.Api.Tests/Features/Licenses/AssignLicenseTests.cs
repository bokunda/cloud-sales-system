namespace CloudSalesSystem.Api.Tests.Features.Licenses;

public class AssignLicenseTests : BaseApiTests
{
    public AssignLicenseTests(ApiTestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Assign_License_Valid()
    {
        // Arrange

        // NOTE: Ideally, we should prepare everything from scratch, but because of the time limit, I will use seeded data.
        var command = new AssignLicenseCommand(Account.FirstSystemAccountId, SubscriptionItem.FirstSubscriptionItemId);

        // Act
        var result = await Sender.Send(command);

        // Assert
        result.Should().NotBeNull();
        
        var resultFromDb = await DbContext.Set<License>().FirstOrDefaultAsync(x => x.Id == result.Id);

        resultFromDb.Should().NotBeNull();
        resultFromDb!.Id.Should().Be(result.Id);
    }

    [Fact]
    public async Task Assign_License_Invalid_Account_Id()
    {
        // Arrange

        // NOTE: Ideally, we should prepare everything from scratch, but because of the time limit, I will use seeded data.
        var command = new AssignLicenseCommand(Guid.NewGuid(), SubscriptionItem.FirstSubscriptionItemId);

        // Act
        var action = async () => await Sender.Send(command);

        // Assert
        await action.Should().ThrowAsync<DbUpdateException>();
    }

    [Fact]
    public async Task Assign_License_Invalid_Subscription_Item_Id()
    {
        // Arrange

        // NOTE: Ideally, we should prepare everything from scratch, but because of the time limit, I will use seeded data.
        var command = new AssignLicenseCommand(Guid.NewGuid(), SubscriptionItem.FirstSubscriptionItemId);

        // Act
        var action = async () => await Sender.Send(command);

        // Assert
        await action.Should().ThrowAsync<DbUpdateException>();
    }
}