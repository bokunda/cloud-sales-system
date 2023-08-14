namespace CloudSalesSystem.Application.SubscriptionItems.GetSubscriptionItems;

internal sealed class GetSubscriptionItemsQueryHandler :
    IPagedRequestHandler<GetSubscriptionItemsQuery, GetSubscriptionItemsResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetSubscriptionItemsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<PagedResponse<GetSubscriptionItemsResponse>> Handle(GetSubscriptionItemsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var totalCount = await connection
            .ExecuteScalarAsync<long>(
                GetSubscriptionItemsCountQuery(request.SubscriptionId, request.CustomerId, request.AccountId),
                new
                {
                    request.SubscriptionId,
                    request.CustomerId,
                    request.AccountId,
                });

        var accounts = await connection
            .QueryAsync<GetSubscriptionItemsResponse>(
                GetSubscriptionItemsQuery(request.SubscriptionId, request.CustomerId, request.AccountId),
                new
                {
                    request.SubscriptionId,
                    request.CustomerId,
                    request.AccountId,
                    request.PageSize,
                    Offset = (request.PageNumber - 1) * request.PageSize
                });

        return new PagedResponse<GetSubscriptionItemsResponse>
        {
            Items = accounts,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }

    private static string GetSubscriptionItemsCountQuery(Guid? subscriptionId, Guid? customerId, Guid? accountId) =>
        $"""
        SELECT
            COUNT(*)
        FROM subscription_items AS si
        WHERE 
                {(subscriptionId.HasValue ? "si.subscription_id = @SubscriptionId AND" : string.Empty)}
                {(customerId.HasValue ? "si.customer_id = @CustomerId AND" : string.Empty)}
                {(accountId.HasValue ? "si.account_id = @AccountId AND" : string.Empty)}
                {(subscriptionId.HasValue || customerId.HasValue || accountId.HasValue ? "1 = 1" : string.Empty)}
        """;

    // TODO: Join with accounts!
    private static string GetSubscriptionItemsQuery(Guid? subscriptionId, Guid? customerId, Guid? accountId) =>
        $"""
        SELECT
            si.id AS Id,
            si.subscription_id AS SubscriptionId,
            si.product_id AS ProductId,
            si.quantity AS Quantity,
            si.state AS State,
            si.valid_to_date AS ValidToDate
        FROM subscription_items AS si
        WHERE
                {(subscriptionId.HasValue ? "si.subscription_id = @SubscriptionId AND" : string.Empty)}
                {(customerId.HasValue ? "si.customer_id = @CustomerId AND" : string.Empty)}
                {(accountId.HasValue ? "si.account_id = @AccountId AND" : string.Empty)}
                {(subscriptionId.HasValue || customerId.HasValue || accountId.HasValue ? "1 = 1" : string.Empty)}
        ORDER BY si.id
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY
        """;
}