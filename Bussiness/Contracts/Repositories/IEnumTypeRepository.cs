using Bussiness.Contracts.Repositories.Common;
using Bussiness.DomainObjects;

namespace Bussiness.Contracts.Repositories
{
    public interface IEnumTypeRepository
         : IRepository<EnumTypeDO>
    {
        public Task<EnumTypeDO> GetAllEnumTypeByName(string? propertiesToInclude, string enumTypeName, CancellationToken cancellationToken);
    }
}
