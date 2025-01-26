using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class CoreAssetCustomTemplateRepository
    : BaseRepository<CoreAssetCustomTemplateDO>,
        ICoreAssetCustomTemplateRepository
    {
        #region Ctor

        public CoreAssetCustomTemplateRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public CoreAssetCustomTemplateRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
