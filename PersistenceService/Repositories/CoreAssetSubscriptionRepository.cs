using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CoreAssetSubscriptionRepository
    : BaseRepository<CoreAssetSubscriptionDO>,
        ICoreAssetSubscriptionRepository
    {
        #region Ctor

        public CoreAssetSubscriptionRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CoreAssetSubscriptionRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
