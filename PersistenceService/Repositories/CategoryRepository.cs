using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CategoryRepository
    : BaseRepository<CategoryDO>,
        ICategoryRepository
    {
        #region Ctor

        public CategoryRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CategoryRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
