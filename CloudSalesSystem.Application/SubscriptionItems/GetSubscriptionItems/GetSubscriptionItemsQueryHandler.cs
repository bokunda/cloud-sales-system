namespace CloudSalesSystem.Application.SubscriptionItems.GetSubscriptionItems;

internal sealed class GetSubscriptionItemsQueryHandler :
    IPagedRequestHandler<GetSubscriptionItemsQuery, GetSubscriptionItemsResponse>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetSubscriptionItemsQueryHandler(
        ICurrentUserProvider currentUserProvider,
        ISqlConnectionFactory sqlConnectionFactory)
    {
        _currentUserProvider = currentUserProvider;
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<PagedResponse<GetSubscriptionItemsResponse>> Handle(GetSubscriptionItemsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var totalCount = await connection
            .ExecuteScalarAsync<long>(
                GetSubscriptionItemsCountQuery(request.SubscriptionId, _currentUserProvider.CustomerId, request.AccountId),
                new
                {
                    request.SubscriptionId,
                    _currentUserProvider.CustomerId,
                    request.AccountId,
                });

        var accounts = await connection
            .QueryAsync<GetSubscriptionItemsResponse>(
                GetSubscriptionItemsQuery(request.SubscriptionId, _currentUserProvider.CustomerId, request.AccountId),
                new
                {
                    request.SubscriptionId,
                    _currentUserProvider.CustomerId,
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
        {GetJoinedTables()}
        {GetWhereClause(subscriptionId, customerId, accountId)}
        """;

    private static string GetSubscriptionItemsQuery(Guid? subscriptionId, Guid? customerId, Guid? accountId) =>
        $"""
        SELECT DISTINCT
            si.id AS Id,
            si.subscription_id AS SubscriptionId,
            si.product_id AS ProductId,
            si.quantity AS Quantity,
            si.state AS State,
            si.valid_to_date AS ValidToDate
        FROM subscription_items AS si
        {GetJoinedTables()}
        {GetWhereClause(subscriptionId, customerId, accountId)}
        ORDER BY si.id
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY
        """;

    private static string GetJoinedTables() =>
        """
        LEFT JOIN subscriptions s ON si.subscription_id = s.id
        LEFT JOIN customer_subscriptions cs ON s.id = cs.subscription_id 
        LEFT JOIN customers c ON cs.customer_id = c.id
        LEFT JOIN accounts a ON c.id = a.customer_id
        LEFT JOIN licenses l ON l.account_id = a.id
        """;

    private static string GetWhereClause(Guid? subscriptionId, Guid? customerId, Guid? accountId) =>
        $"""
        WHERE
            { (subscriptionId.HasValue ? "si.subscription_id = @SubscriptionId AND" : string.Empty)} 
            { (customerId.HasValue ? "cs.customer_id = @CustomerId AND" : string.Empty)} 
            { (accountId.HasValue ? "l.account_id = @AccountId AND" : string.Empty)} 
            { (subscriptionId.HasValue || customerId.HasValue || accountId.HasValue ? "1 = 1" : string.Empty)} 
        """ ;
}