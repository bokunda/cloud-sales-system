namespace CloudSalesSystem.Application.Abstractions.CloudServices.Models;

public sealed record RevokeServiceItemLicenseKeyRequest(Guid SubscriptionId, Guid ServiceId, string Key);