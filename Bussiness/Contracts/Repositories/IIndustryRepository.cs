using Bussiness.Contracts.Repositories.Common;
using Bussiness.DomainObjects;

namespace Bussiness.Contracts.Repositories
{
    public interface IIndustryRepository
         : IRepository<IndustryDO>
    {
        public Task<IndustryDO> GetAllIndustryByName(string? propertiesToInclude, string industryName, CancellationToken cancellationToken);
    }
}
