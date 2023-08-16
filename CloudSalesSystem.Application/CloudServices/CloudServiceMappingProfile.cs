namespace CloudSalesSystem.Application.CloudServices;

public class CloudServiceMappingProfile : Profile
{
    public CloudServiceMappingProfile()
    {
        CreateMap<AvailableServiceItem, GetCloudServiceDetailsResponse>();
        CreateMap<AvailableServiceItem, GetCloudServicesItemResponse>();
        CreateMap<OrderServiceItemResponse, OrderLicenseResponse>();
    }
}