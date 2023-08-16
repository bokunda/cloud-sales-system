namespace CloudSalesSystem.Application.Abstractions.CloudServices.Models;

public sealed record ServiceItemLicenseKeyRequest(Guid ServiceId, int Amount);