using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    internal class OrganizationRoleRepository
    : BaseRepository<OrganizationRoleDO>,
        IOrganizationRoleRepository
    {
        private Guid id;
        #region Ctor

        public OrganizationRoleRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public OrganizationRoleRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion

        #region Methods
        public async Task<OrganizationRoleDO> GetAllIndustryByName(string? propertiesToInclude, string name, CancellationToken cancellationToken)
        {

            try
            {
                // Prepare the base query for bookings by customer ID
                var query = ReadAll().Where(b => b.Id == id);

                // Include specified related properties
                if (!string.IsNullOrWhiteSpace(propertiesToInclude))
                {
                    string[] properties = propertiesToInclude.Split(',');
                    foreach (string property in properties)
                    {
                        query = query.Include(property);
                    }
                }

                // Execute the query and return the list of bookings
                var bookings = await query.FirstOrDefaultAsync(cancellationToken);
                return bookings;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching bookings.", ex);
            }
        }
        #endregion
    }
}
