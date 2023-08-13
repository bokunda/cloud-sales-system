namespace CloudSalesSystem.Application.Abstractions.CloudComputing.Models;

public sealed record AvailableServiceItem(
    Guid Id,
    string Name,
    string Description,
    decimal Price);