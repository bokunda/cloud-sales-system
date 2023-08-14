namespace CloudSalesSystem.Domain.Repositories;

public interface IRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TEntity id, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}