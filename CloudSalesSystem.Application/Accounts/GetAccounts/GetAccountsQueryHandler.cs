namespace CloudSalesSystem.Application.Accounts.GetAccounts;

internal sealed class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IReadOnlyList<AccountResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAccountsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<IReadOnlyList<AccountResponse>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        var accounts = await connection
            .QueryAsync<AccountResponse>(
                GetAccountsQuery(), 
                new { request.CustomerId });

        return accounts.ToList();
    }

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
        """;
}