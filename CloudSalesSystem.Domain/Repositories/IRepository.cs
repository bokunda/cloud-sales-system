﻿namespace CloudSalesSystem.Domain.Repositories;

public interface IRepository<TEntity, in TEntityId>
    where TEntity : Entity<TEntityId>
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}