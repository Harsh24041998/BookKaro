using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CoreAssetTemplateRepository
    : BaseRepository<CoreAssetTemplateDO>,
        ICoreAssetTemplateRepository
    {
        #region Ctor

        public CoreAssetTemplateRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CoreAssetTemplateRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
