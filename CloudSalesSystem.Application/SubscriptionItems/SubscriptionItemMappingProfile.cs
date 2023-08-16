using CloudSalesSystem.Application.SubscriptionItems.UpdateValidTo;

namespace CloudSalesSystem.Application.SubscriptionItems;

public class SubscriptionItemMappingProfile : Profile
{
    public SubscriptionItemMappingProfile()
    {
        CreateMap<SubscriptionItem, UpdateSubscriptionItemQuantityResponse>()
            .ForMember(src => src.SubscriptionItemId, opt => opt.MapFrom(dest => dest.Id));
        CreateMap<SubscriptionItem, UpdateValidToSubscriptionItemResponse>()
            .ForMember(src => src.SubscriptionItemId, opt => opt.MapFrom(dest => dest.Id));
    }
}