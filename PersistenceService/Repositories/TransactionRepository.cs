using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class TransactionRepository
    : BaseRepository<TransactionDO>,
        ITransactionRepository
    {
        #region Ctor

        public TransactionRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public TransactionRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion
    }
}
