namespace CloudSalesSystem.Application.Abstractions.CloudServices.Models;

public sealed record AvailableServiceItem(
    Guid Id,
    string Name,
    string Description,
    decimal Price);