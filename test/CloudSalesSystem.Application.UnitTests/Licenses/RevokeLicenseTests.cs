namespace CloudSalesSystem.Application.UnitTests.Licenses;

public class RevokeLicenseTests
{
    [Fact]
    public async Task Revoke_License_Successfully()
    {
        // Arrange
        var licenseId = Guid.NewGuid();
        var accountId = Guid.NewGuid();
        var subscriptionItemId = Guid.NewGuid();
        var key = $"{Guid.NewGuid()}";

        var command = new RevokeServiceLicenseCommand(licenseId);

        var licenseRepositoryFake = A.Fake<ILicenseRepository>();
        A.CallTo(() => licenseRepositoryFake.GetByIdAsync(A<Guid>._, A<CancellationToken>._))
            .Returns(Task.FromResult<License?>(License.Create(accountId, subscriptionItemId, key)));

        var handler = new RevokeServiceLicenseCommandHandler(
            licenseRepositoryFake,
            A.Fake<IUnitOfWork>(),
            A.Fake<IMapper>());

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Revoke_License_Failed()
    {
        // Arrange
        var licenseId = Guid.NewGuid();
        var command = new RevokeServiceLicenseCommand(licenseId);

        var licenseRepositoryFake = A.Fake<ILicenseRepository>();
        A.CallTo(() => licenseRepositoryFake.GetByIdAsync(A<Guid>._, A<CancellationToken>._))
            .Returns(Task.FromResult<License?>(null));

        var handler = new RevokeServiceLicenseCommandHandler(
            licenseRepositoryFake,
            A.Fake<IUnitOfWork>(),
            A.Fake<IMapper>());

        // Act
        var action = async () => await handler.Handle(command, default);

        // Assert
        await action.Should().ThrowAsync<InvalidOperationException>().WithMessage("License doesn't exists!");
    }
}