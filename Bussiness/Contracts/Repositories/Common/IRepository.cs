namespace Bussiness.Contracts.Repositories.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Signatures

        IQueryable<TEntity> ReadAll();
        IQueryable<TEntity> ReadAllAsNoTracking();
        Task<IList<TEntity>> ReadAllAsync(string? propertiesToInclude, CancellationToken cancellationToken);
        Task<IList<TEntity>> ReadAllAsNoTrackingAsync(string? propertiesToInclude, CancellationToken cancellationToken);
        Task<TEntity?> ReadByIdAsync(Guid id, string? propertiesToInclude, CancellationToken cancellationToken);
        Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Delete(TEntity entity, CancellationToken cancellationToken);

        #endregion
    }
}
