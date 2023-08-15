namespace CloudSalesSystem.Application.CloudServices.OrderLicense;

public record OrderLicenseResponse(Guid TransactionId,
    DateTime TransactionDateTime,
    Guid ServiceId,
    string ServiceName,
    int TotalItems,
    decimal PricePerItem,
    decimal TotalPrice,
    DateOnly ValidToDate);