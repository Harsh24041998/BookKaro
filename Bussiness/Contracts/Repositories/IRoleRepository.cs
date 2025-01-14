using Bussiness.Contracts.Repositories.Common;
using Bussiness.DomainObjects;

namespace Bussiness.Contracts.Repositories
{
    public interface IRoleRepository
         : IRepository<RoleDO>
    {
        public Task<List<RoleDO>> GetAllActiveRole(string? propertiesToInclude, bool isActive, CancellationToken cancellationToken);
    }
}
