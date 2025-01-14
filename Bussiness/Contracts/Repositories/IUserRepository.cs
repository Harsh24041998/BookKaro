using Bussiness.Contracts.Repositories.Common;
using Bussiness.DomainObjects;

namespace Bussiness.Contracts.Repositories
{
    public interface IUserRepository
         : IRepository<UserDO>
    {
        public Task<UserDO> GetUserbyMobileNumber(string? propertiesToInclude, string mobileNumber, CancellationToken cancellationToken);
    }
}
