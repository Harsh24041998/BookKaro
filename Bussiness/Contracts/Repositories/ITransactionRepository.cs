﻿using Bussiness.Contracts.Repositories.Common;
using Bussiness.DomainObjects;

namespace Bussiness.Contracts.Repositories
{
    public interface ITransactionRepository
         : IRepository<TransactionDO>
    {
    }
}
