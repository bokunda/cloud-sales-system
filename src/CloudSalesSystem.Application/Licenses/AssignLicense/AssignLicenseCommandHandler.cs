namespace CloudSalesSystem.Application.Licenses.AssignLicense;

internal sealed class AssignLicenseCommandHandler : IRequestHandler<AssignLicenseCommand, AssignLicenseResponse>
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly ISubscriptionItemRepository _subscriptionItemRepository;
    private readonly ICloudComputingService _cloudComputingService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AssignLicenseCommandHandler(
        ILicenseRepository licenseRepository,
        ISubscriptionItemRepository subscriptionItemRepository,
        ICloudComputingService cloudComputingService,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _licenseRepository = licenseRepository;
        _subscriptionItemRepository = subscriptionItemRepository;
        _cloudComputingService = cloudComputingService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AssignLicenseResponse> Handle(AssignLicenseCommand request, CancellationToken cancellationToken)
    {
        License? unassignedLicense = null;

        // Check do we have a license that is not assigned
        var unassignedLicenses = await _licenseRepository.GetRevokedLicenses(null, request.SubscriptionItemId, cancellationToken);

        if (unassignedLicenses.Any())
        {
            unassignedLicense = unassignedLicenses.First();
            unassignedLicense.AssignAccount(request.AccountId);
        }
        else
        {
            // Check do we reached maximum limit of licenses
            var assignedLicensesCount = await _licenseRepository.GetAssignedLicensesCount(null, request.SubscriptionItemId, cancellationToken);
            var subscriptionItemDetails = await _subscriptionItemRepository.GetByIdAsync(request.SubscriptionItemId, cancellationToken);

            if (assignedLicensesCount >= subscriptionItemDetails!.Quantity)
            {
                throw new InvalidOperationException("Maximum amount of issued licenses is reached!");
            }

            // Get new license key
            var licenseKey = (await _cloudComputingService
                .GetServiceItemLicenseKeys(
                    new ServiceItemLicenseKeyRequest(subscriptionItemDetails.ProductId, 1), 
                    cancellationToken))
                .Single();

            // Create DB entity
            unassignedLicense = License.Create(request.AccountId, subscriptionItemDetails.Id, licenseKey.Key);
            _licenseRepository.Add(unassignedLicense);
        }

        var mappedResult = _mapper.Map<AssignLicenseResponse>(unassignedLicense);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return mappedResult;
    }
}