﻿using Bussiness.Contracts.Repositories;
using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore;
using PersistenceService.Configurations;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Repositories
{
    internal class IndustryRepository
    : BaseRepository<IndustryDO>,
        IIndustryRepository
    {
        #region Ctor

        public IndustryRepository(BookKaroDBContext dbContext) : base(dbContext) { }
        public IndustryRepository(BookKaroDBContext dbContext, bool isContextShared) : base(dbContext, isContextShared) { }

        #endregion

        #region Methods
        public async Task<IndustryDO> GetAllIndustryByName(string? propertiesToInclude, string name, CancellationToken cancellationToken)
        {

            try
            {
                // Prepare the base query for bookings by customer ID
                var query = ReadAll().Where(b => b.Name == name);

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
