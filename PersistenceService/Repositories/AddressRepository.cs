using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class AddressRepository
    : BaseRepository<AddressDO>,
        IAddressRepository
    {
        #region Ctor

        public AddressRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public AddressRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
