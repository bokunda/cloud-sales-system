namespace CloudSalesSystem.Domain.UnitTests.Customers;

public class CustomerBaseTest : BaseTest
{
    [Fact]
    public void Create_Should_Raise_UseCreatedDomainEvent()
    {
        // Arrange
        const string name = "Test Name";
        const string description = "Description Test";

        // Act
        var customer = Customer.Create(name, description);

        // Assert
        var userCreatedDomainEvent = AssertDomainEventWasPublished<CustomerCreatedDomainEvent>(customer);

        userCreatedDomainEvent.CustomerId.Should().Be(customer.Id);
    }
}