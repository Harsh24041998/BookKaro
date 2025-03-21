﻿using Bussiness.Contracts.Repositories.Common;
using Bussiness.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Bussiness.Contracts.Repositories;
using PersistenceService.Repositories;
using PersistenceService.Repositories.Common;

namespace PersistenceService.Configurations
{
    public static class ConfigureServices
    {
        #region Methods

        public static IServiceCollection InjectPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookKaroDBContext>(options =>
            options.UseSqlServer(configuration["DatabaseConfig:BIndia:BookKaroDbConnectionString"]));

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IDataTypeRepository, DataTypeRepository>();
            services.AddScoped<IEnumTypeRepository, EnumTypeRepository>();
            services.AddScoped<IEnumValueRepository, EnumValueRepository>();
            services.AddScoped<IIndustryRepository, IndustryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICoreAssetRepository, CoreAssetRepository>();
            services.AddScoped<ICoreAssetTemplateRepository, CoreAssetTemplateRepository>();
            services.AddScoped<ICoreAssetCustomTemplateRepository, CoreAssetCustomTemplateRepository>();
            services.AddScoped<ICoreAssetCancellationPolicyRepository, CoreAssetCancellationPolicyRepository>();
            services.AddScoped<ICoreAssetBookingRepository, CoreAssetBookingRepository>();
            services.AddScoped<ICoreAssetBookingSlotRepository, CoreAssetBookingSlotRepository>();
            services.AddScoped<ICoreAssetBookingCancellationRepository, CoreAssetBookingCancellationRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOrganizationRoleRepository, OrganizationRoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ICoreAssetSubscriptionRepository, CoreAssetSubscriptionRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }

        #endregion
    }
}
