namespace CloudSalesSystem.Application.Licenses.RevokeLicense;

internal sealed class RevokeServiceLicenseCommandHandler : IRequestHandler<RevokeServiceLicenseCommand, RevokeServiceLicenseResponse>
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RevokeServiceLicenseCommandHandler(
        ILicenseRepository licenseRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _licenseRepository = licenseRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RevokeServiceLicenseResponse> Handle(RevokeServiceLicenseCommand request, CancellationToken cancellationToken)
    {
        var license = await _licenseRepository.GetByIdAsync(request.LicenseId, cancellationToken);

        if (license is null)
        {
            throw new InvalidOperationException("License doesn't exists!");
        }

        license.RemoveAccount();

        var mappedResult = _mapper.Map<RevokeServiceLicenseResponse>(license);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return mappedResult;
    }
}