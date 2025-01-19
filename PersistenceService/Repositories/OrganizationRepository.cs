using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class OrganizationRepository
    : BaseRepository<OrganizationDO>,
        IOrganizationRepository
    {
        #region Ctor

        public OrganizationRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public OrganizationRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
