namespace CloudSalesSystem.Application.Licenses.RevokeLicense;

internal sealed class RevokeServiceLicenseCommandHandler : IRequestHandler<RevokeServiceLicenseCommand, RevokeServiceLicenseResponse>
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RevokeServiceLicenseCommandHandler(
        ILicenseRepository licenseRepository,
        IUnitOfWork unitOfWork)
    {
        _licenseRepository = licenseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RevokeServiceLicenseResponse> Handle(RevokeServiceLicenseCommand request, CancellationToken cancellationToken)
    {
        var license = await _licenseRepository.GetByIdAsync(request.LicenseId, cancellationToken);

        if (license is null)
        {
            throw new InvalidOperationException("License doesn't exists!");
        }

        license.RemoveAccount();
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RevokeServiceLicenseResponse();
    }
}