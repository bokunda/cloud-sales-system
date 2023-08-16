namespace CloudSalesSystem.Application.CloudServices.OrderLicense;

public record OrderLicenseResponse
{
    public Guid TransactionId { get; init; }
    public DateTime TransactionDateTime { get; init; }
    public Guid SubscriptionItemId { get; set; }
    public Guid ServiceId { get; init; }
    public string ServiceName { get; set; } = string.Empty;
    public int TotalItems { get; init; }
    public decimal PricePerItem { get; init; }
    public decimal TotalPrice { get; init; }
    public DateOnly ValidToDate { get; init; }
}