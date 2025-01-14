using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class RoleRepository
    : BaseRepository<RoleDO>,
        IRoleRepository
    {
        #region Ctor

        public RoleRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public RoleRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion

        #region Methods

        public async Task<List<RoleDO>> GetAllActiveRole(string? propertiesToInclude, bool isActive, CancellationToken cancellationToken)
        {
            try
            {
                var query = ReadAll().Where(n => n.IsActive == isActive);

                if (!string.IsNullOrWhiteSpace(propertiesToInclude))
                {
                    string[] properties = propertiesToInclude.Split(',');

                    foreach (string property in properties)
                    {
                        query = query.Include(property);
                    }
                }


                // Fetch the employee list asynchronously
                var employeeList = await query.ToListAsync(cancellationToken);

                return employeeList;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while generating the next sequence value.", ex);
            }
        }

        #endregion
    }
}
