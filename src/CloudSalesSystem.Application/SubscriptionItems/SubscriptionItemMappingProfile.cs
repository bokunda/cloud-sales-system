using CloudSalesSystem.Application.SubscriptionItems.UpdateValidTo;

namespace CloudSalesSystem.Application.SubscriptionItems;

public class SubscriptionItemMappingProfile : Profile
{
    public SubscriptionItemMappingProfile()
    {
        CreateMap<SubscriptionItem, UpdateSubscriptionItemQuantityResponse>();
        CreateMap<SubscriptionItem, UpdateValidToSubscriptionItemResponse>();
    }
}