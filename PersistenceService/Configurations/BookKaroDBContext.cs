using Microsoft.EntityFrameworkCore;
using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Bussiness.DomainObjects.Common;

namespace PersistenceService.Configurations
{
    public sealed class BookKaroDBContext
        : DbContext
    {
        #region Ctor

        //public BASDBContext() { }
        public BookKaroDBContext(DbContextOptions<BookKaroDBContext> options) : base(options) { }

        #endregion

        #region Properties

        public DbSet<RoleDO> Roles { get; set; }
        public DbSet<GenderDO> Genders { get; set; }
        public DbSet<DataTypeDO> DataTypes { get; set; }
        public DbSet<EnumTypeDO> EnumTypes { get; set; }
        public DbSet<EnumValueDO> EnumValues { get; set; }
        public DbSet<IndustryDO> Industries { get; set; }
        public DbSet<CategoryDO> Categories { get; set; }
        public DbSet<CoreAssetDO> CoreAssets { get; set; }
        public DbSet<CoreAssetTemplateDO> CoreAssetTemplates { get; set; }
        public DbSet<CoreAssetCustomTemplateDO> CoreAssetCustomTemplates { get; set; }
        public DbSet<CoreAssetCancellationPolicyDO> CoreAssetCancellationPolicys { get; set; }
        public DbSet<OrganizationDO> Organizations { get; set; }
        public DbSet<UserDO> Users { get; set; }

        #endregion


        #region Methods
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    //var configuration = new ConfigurationBuilder()
        //    //    .SetBasePath(Directory.GetCurrentDirectory())
        //    //    .AddJsonFile("ConfigurationSettings.json", optional: false, reloadOnChange: true)
        //    //    .Build();

        //    if (!options.IsConfigured)
        //    {
        //        //options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
        //    }
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleDO>().ToTable("RefRole",schema:"Master");
            modelBuilder.Entity<GenderDO>().ToTable("RefGender");
            modelBuilder.Entity<DataTypeDO>().ToTable("RefDataType");
            modelBuilder.Entity<EnumTypeDO>().ToTable("RefEnumType");
            modelBuilder.Entity<IndustryDO>().ToTable("RefIndustry");
            modelBuilder.Entity<EnumValueDO>().ToTable("RefEnumValue");
            modelBuilder.Entity<AddressDO>().ToTable("RefAddress");
            modelBuilder.Entity<CategoryDO>().ToTable("RefCategory");
            modelBuilder.Entity<CoreAssetDO>().ToTable("CoreAsset");
            modelBuilder.Entity<CoreAssetTemplateDO>().ToTable("CoreAssetTemplate");
            modelBuilder.Entity<CoreAssetCustomTemplateDO>().ToTable("CoreAssetCustomTemplate");
            modelBuilder.Entity<CoreAssetCancellationPolicyDO>().ToTable("CoreAssetCancellationPolicy");
            modelBuilder.Entity<OrganizationDO>().ToTable("RefOrganization");
            modelBuilder.Entity<OrganizationRoleDO>().ToTable("RefOrganizationRole");
            modelBuilder.Entity<UserDO>().ToTable("RefUser");
            modelBuilder.Entity<SubscriptionDO>().ToTable("RefSubscription");
        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (EntityEntry entityEntry in this.ChangeTracker.Entries())
            {
                if (entityEntry.State == EntityState.Added)
                {
                    AuditableDO auditableEntity = (AuditableDO)entityEntry.Entity;
                    auditableEntity.CreatedOn = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    AuditableDO auditableEntity = (AuditableDO)entityEntry.Entity;
                    auditableEntity.UpdatedOn = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }

        #endregion
    }
}
