using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class EnumValueRepository
    : BaseRepository<EnumValueDO>,
        IEnumValueRepository
    {
        #region Ctor

        public EnumValueRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public EnumValueRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
