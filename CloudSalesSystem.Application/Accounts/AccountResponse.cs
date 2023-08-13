namespace CloudSalesSystem.Application.Accounts;

public class AccountResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
}