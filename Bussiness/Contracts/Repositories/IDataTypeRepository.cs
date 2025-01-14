using Bussiness.Contracts.Repositories.Common;
using Bussiness.DomainObjects;

namespace Bussiness.Contracts.Repositories
{
    public interface IDataTypeRepository
         : IRepository<DataTypeDO>
    {
        public Task<DataTypeDO> GetAllDataTypeByName(string? propertiesToInclude, string dataTypeName, CancellationToken cancellationToken);
    }
}
