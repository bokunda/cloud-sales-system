namespace CloudSalesSystem.Application.SubscriptionItems.UpdateQuantity;

internal sealed class UpdateSubscriptionItemQuantityCommandHandler : IRequestHandler<UpdateSubscriptionItemQuantityCommand, UpdateSubscriptionItemQuantityResponse>
{
    private readonly ICloudComputingService _cloudComputingService;
    private readonly ISubscriptionItemRepository _subscriptionItemRepository;
    private readonly ILicenseRepository _licenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateSubscriptionItemQuantityCommandHandler(
        ICloudComputingService cloudComputingService,
        ISubscriptionItemRepository subscriptionItemRepository,
        ILicenseRepository licenseRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _cloudComputingService = cloudComputingService;
        _subscriptionItemRepository = subscriptionItemRepository;
        _licenseRepository = licenseRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateSubscriptionItemQuantityResponse> Handle(UpdateSubscriptionItemQuantityCommand request, CancellationToken cancellationToken)
    {
        var subscriptionItem = await _subscriptionItemRepository.GetByIdAsync(request.SubscriptionItemId, cancellationToken);

        if (subscriptionItem is null)
        {
            throw new InvalidOperationException("Subscription Item doesn't exists!");
        }

        // Get the data
        var assignedLicensesCount = await _licenseRepository.GetAssignedLicensesCount(subscriptionItem.SubscriptionId, subscriptionItem.Id, cancellationToken);
        var revokedLicenses = await _licenseRepository.GetRevokedLicenses(subscriptionItem.SubscriptionId, request.SubscriptionItemId, cancellationToken);

        // Prepare the counts
        var licensesToRemoveCount = subscriptionItem.Quantity - request.Quantity;
        var unassignedLicensesCount = subscriptionItem.Quantity - assignedLicensesCount;
        var notTrackedLicensesCount = unassignedLicensesCount - revokedLicenses.Count;

        // Check are there any enough licenses to be revoked
        if (notTrackedLicensesCount < licensesToRemoveCount)
        {
            throw new InvalidOperationException("There are no enough free licenses to revoke!");
        }

        // Handle unassigned licenses
        if (licensesToRemoveCount > 0 && unassignedLicensesCount < licensesToRemoveCount)
        {
            await HandleUnassignedLicenses(cancellationToken, revokedLicenses, licensesToRemoveCount, notTrackedLicensesCount, subscriptionItem);
        }

        // Set the data
        subscriptionItem.SetQuantity(request.Quantity);

        var mappedResult = _mapper.Map<UpdateSubscriptionItemQuantityResponse>(subscriptionItem);

        // Preserve changes
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return mappedResult;
    }

    private async Task HandleUnassignedLicenses(CancellationToken cancellationToken, ICollection<License> revokedLicenses,
        int licensesToRemoveCount, int notTrackedLicensesCount, SubscriptionItem subscriptionItem)
    {
        var licensesToRemove = revokedLicenses.Take(licensesToRemoveCount - notTrackedLicensesCount).ToList();

        // Revoke licenses
        var data = licensesToRemove.Select(l =>
                new RevokeServiceItemLicenseKeyRequest(
                    subscriptionItem.SubscriptionId,
                    subscriptionItem.ProductId,
                    l.Key!))
            .ToList();

        var result = await _cloudComputingService.RevokeLicenseKeys(data, cancellationToken);

        if (!result)
        {
            throw new InvalidOperationException("Cannot revoke licenses on CCP side!");
        }

        // Logic delete of revoked licenses
        licensesToRemove.ForEach(license => license.SetIsDeleted());
    }
}