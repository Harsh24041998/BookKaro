using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    public class UserRepository
    : BaseRepository<UserDO>,
        IUserRepository
    {
        #region Ctor

        public UserRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public UserRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion

        #region Methods

        public async Task<UserDO> GetUserbyMobileNumber(string? propertiesToInclude, string mobileNumber, CancellationToken cancellationToken)
        {
            try
            {
                var query = ReadAll().Where(n => n.MobileNumber == mobileNumber && n.IsActive==true);

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

                return employeeList.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while generating the next sequence value.", ex);
            }
        }

        #endregion
    }
}
