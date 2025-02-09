using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CoreAssetBookingRepository
    : BaseRepository<CoreAssetBookingDO>,
        ICoreAssetBookingRepository
    {
        #region Ctor

        public CoreAssetBookingRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CoreAssetBookingRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
