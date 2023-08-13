namespace CloudSalesSystem.Application.Accounts.GetAccounts;

internal sealed class GetAccountsQueryHandler : IPagedRequestHandler<GetAccountsQuery, AccountResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAccountsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<PagedResponse<AccountResponse>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var totalCount = await connection
            .ExecuteScalarAsync<long>(
                GetAccountsCountQuery(),
                new { request.CustomerId });

        var accounts = await connection
            .QueryAsync<AccountResponse>(
                GetAccountsQuery(),
                new
                {
                    request.CustomerId, 
                    request.PageSize, 
                    Offset = (request.PageNumber - 1) * request.PageSize
                });

        return new PagedResponse<AccountResponse>
        {
            Items = accounts,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }

    private static string GetAccountsCountQuery() =>
        """
        SELECT
            COUNT(*)
        FROM accounts AS a
        WHERE customer_id = @CustomerId
        """;

    private static string GetAccountsQuery() =>
        """
        SELECT
            a.id AS Id,
            a.name AS Name,
            a.description AS Description,
            a.customer_id AS CustomerId,
            c.name AS CustomerName
        FROM accounts AS a
        JOIN customers AS c ON a.customer_id = c.id
        WHERE customer_id = @CustomerId
        ORDER BY a.id
        OFFSET @Offset ROWS
        FETCH NEXT @PageSize ROWS ONLY
        """;
}