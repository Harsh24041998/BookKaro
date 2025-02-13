using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CoreAssetBookingCancellationRepository
    : BaseRepository<CoreAssetBookingCancellationDO>,
        ICoreAssetBookingCancellationRepository
    {
        #region Ctor

        public CoreAssetBookingCancellationRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CoreAssetBookingCancellationRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
