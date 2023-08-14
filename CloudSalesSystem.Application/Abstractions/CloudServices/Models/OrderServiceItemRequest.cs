namespace CloudSalesSystem.Application.Abstractions.CloudServices.Models;

public sealed record OrderServiceItemRequest(Guid ServiceId, int Amount);