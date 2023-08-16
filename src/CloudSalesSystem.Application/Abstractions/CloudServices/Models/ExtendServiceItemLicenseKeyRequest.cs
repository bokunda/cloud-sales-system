namespace CloudSalesSystem.Application.Abstractions.CloudServices.Models;

public sealed record ExtendServiceItemLicenseKeyRequest(Guid SubscriptionId, Guid ServiceId, string Key, DateOnly ValidToDate);