using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CoreAssetCancellationPolicyRepository
    : BaseRepository<CoreAssetCancellationPolicyDO>,
        ICoreAssetCancellationPolicyRepository
    {
        #region Ctor

        public CoreAssetCancellationPolicyRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CoreAssetCancellationPolicyRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
