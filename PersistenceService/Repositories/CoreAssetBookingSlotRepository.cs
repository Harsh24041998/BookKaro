using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CoreAssetBookingSlotRepository
    : BaseRepository<CoreAssetBookingSlotDO>,
        ICoreAssetBookingSlotRepository
    {
        #region Ctor

        public CoreAssetBookingSlotRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CoreAssetBookingSlotRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
