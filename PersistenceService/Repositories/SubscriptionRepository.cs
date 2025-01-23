using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class SubscriptionRepository
    : BaseRepository<SubscriptionDO>,
        ISubscriptionRepository
    {
        #region Ctor

        public SubscriptionRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public SubscriptionRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
