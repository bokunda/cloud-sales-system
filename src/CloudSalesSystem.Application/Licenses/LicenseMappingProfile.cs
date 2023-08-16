namespace CloudSalesSystem.Application.Licenses;

public class LicenseMappingProfile : Profile
{
    public LicenseMappingProfile()
    {
        CreateMap<License, AssignLicenseResponse>();
        CreateMap<License, RevokeServiceLicenseResponse>();
    }
}