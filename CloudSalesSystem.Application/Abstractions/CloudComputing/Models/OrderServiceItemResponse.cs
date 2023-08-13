namespace CloudSalesSystem.Application.Abstractions.CloudComputing.Models;

public sealed record OrderServiceItemResponse(
    Guid TransactionId,
    DateTime TransactionDateTime,  
    Guid ServiceId,
    int TotalItems,
    decimal PricePerItem,
    decimal TotalPrice);