namespace CloudSalesSystem.Application.Abstractions.CloudComputing.Models;

public sealed record OrderServiceItemRequest(Guid ServiceId, int Amount);