using Bussiness.Contracts.Repositories.Common;
using Bussiness.DomainObjects.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using PersistenceService.Configurations;

namespace PersistenceService.Repositories.Common
{
    public class BaseRepository<TEntity>
        : IRepository<TEntity> where TEntity : BaseDO
    {
        #region Fields

        protected readonly BookKaroDBContext __bookKaroDBContext;
        protected readonly bool __isContextShared = false;

        #endregion

        #region Ctor

        public BaseRepository(BookKaroDBContext bookKaroDBContext)
        {
            __bookKaroDBContext = bookKaroDBContext;
        }
        public BaseRepository(BookKaroDBContext bookKaroDBContext, bool isContextShared)
        {
            __bookKaroDBContext = bookKaroDBContext;
            __isContextShared = isContextShared;
        }

        #endregion

        #region Methods

        #region Read

        public IQueryable<TEntity> ReadAll()
        {
            return __bookKaroDBContext.Set<TEntity>();
        }
        public IQueryable<TEntity> ReadAllAsNoTracking()
        {
            return __bookKaroDBContext.Set<TEntity>().AsNoTracking();
        }
        public async Task<IList<TEntity>> ReadAllAsync(string? propertiesToInclude, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<TEntity> query = __bookKaroDBContext.Set<TEntity>();

                if (!string.IsNullOrWhiteSpace(propertiesToInclude))
                {
                    string[] properties = propertiesToInclude.Split(',');

                    foreach (string property in properties)
                    {
                        query = query.Include(property);
                    }
                }
                return await query.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IList<TEntity>> ReadAllAsNoTrackingAsync(string? propertiesToInclude, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<TEntity> query = __bookKaroDBContext.Set<TEntity>().AsNoTracking();

                if (!string.IsNullOrWhiteSpace(propertiesToInclude))
                {
                    string[] properties = propertiesToInclude.Split(',');

                    foreach (string property in properties)
                    {
                        query = query.Include(nameof(TEntity) + "." + property);
                    }
                }
                return await query.ToListAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TEntity?> ReadByIdAsync(Guid id, string? propertiesToInclude, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<TEntity> query = __bookKaroDBContext.Set<TEntity>();

                if (!string.IsNullOrWhiteSpace(propertiesToInclude))
                {
                    //string[] properties = propertiesToInclude.Split(',');
                    string[] properties = propertiesToInclude.Split(',')
                                            .Select(p => p.Trim())
                                            .Where(p => !string.IsNullOrEmpty(p))
                                            .ToArray();

                    foreach (string property in properties)
                    {
                        // query = query.Include(nameof(TEntity) + "." + property);
                        query = query.Include(property);
                    }
                }

                return await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Write

        public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                EntityEntry<TEntity> result = __bookKaroDBContext.Add(entity);

                if (!__isContextShared)
                {
                    await __bookKaroDBContext.SaveChangesAsync(cancellationToken);
                }

                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                EntityEntry<TEntity> result = __bookKaroDBContext.Update(entity);

                if (!__isContextShared)
                {
                    await __bookKaroDBContext.SaveChangesAsync(cancellationToken);
                }

                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TEntity> Delete(TEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                EntityEntry<TEntity> result = __bookKaroDBContext.Remove(entity);

                if (!__isContextShared)
                {
                    await __bookKaroDBContext.SaveChangesAsync(cancellationToken);
                }

                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion
    }
}
