namespace CloudSalesSystem.Infrastructure.Repositories;

public class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId> where TEntity : Entity<TEntityId>
{
    protected readonly CloudSalesSystemDbContext DbContext;

    public Repository(CloudSalesSystemDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await DbContext
            .Set<TEntity>()
            .ToListAsync(cancellationToken);

    public async Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken = default) =>
        await DbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id!.Equals(id), cancellationToken);

    public void Add(TEntity entity) => DbContext.Set<TEntity>().Add(entity);

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Attach(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity) => DbContext.Set<TEntity>().Remove(entity);
}