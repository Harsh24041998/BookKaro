using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class GenderRepository
    : BaseRepository<GenderDO>,
        IGenderRepository
    {
        #region Ctor

        public GenderRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public GenderRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion

        #region Methods

        

        #endregion
    }
}
