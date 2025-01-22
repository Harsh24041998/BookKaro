using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CoreAssetRepository
    : BaseRepository<CoreAssetDO>,
        ICoreAssetRepository
    {
        #region Ctor

        public CoreAssetRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CoreAssetRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
