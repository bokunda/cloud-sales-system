namespace CloudSalesSystem.Application.Abstractions.CloudServices.Models;

public sealed record OrderServiceItemResponse(
    Guid TransactionId,
    DateTime TransactionDateTime,  
    Guid ServiceId,
    int TotalItems,
    decimal PricePerItem,
    decimal TotalPrice,
    DateOnly ValidToDate);