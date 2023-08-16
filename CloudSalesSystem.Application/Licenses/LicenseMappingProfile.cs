namespace CloudSalesSystem.Application.Licenses;

public class LicenseMappingProfile : Profile
{
    public LicenseMappingProfile()
    {
        CreateMap<License, AssignLicenseResponse>()
            .ForMember(src => src.LicenseKey, opt => opt.MapFrom(dest => dest.Key));
        CreateMap<License, RevokeServiceLicenseResponse>()
            .ForMember(src => src.LicenseId, opt => opt.MapFrom(dest => dest.Id));
    }
}