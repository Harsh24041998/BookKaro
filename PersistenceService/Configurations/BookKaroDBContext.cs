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
        public DbSet<AddressDO> Addresses { get; set; }
        public DbSet<CategoryDO> Categories { get; set; }
        public DbSet<CoreAssetDO> CoreAssets { get; set; }
        public DbSet<CoreAssetTemplateDO> CoreAssetTemplates { get; set; }
        public DbSet<CoreAssetCustomTemplateDO> CoreAssetCustomTemplates { get; set; }
        public DbSet<CoreAssetCancellationPolicyDO> CoreAssetCancellationPolicys { get; set; }
        public DbSet<CoreAssetBookingDO> CoreAssetBookings { get; set; }
        public DbSet<CoreAssetBookingSlotDO> CoreAssetBookingSlots { get; set; }
        public DbSet<CoreAssetBookingCancellationDO> CoreAssetBookingCancellations { get; set; }
        public DbSet<OrganizationDO> Organizations { get; set; }
        public DbSet<OrganizationRoleDO> OrganizationRoles { get; set; }
        public DbSet<UserDO> Users { get; set; }
        public DbSet<SubscriptionDO> Subscriptions { get; set; }
        public DbSet<CoreAssetSubscriptionDO> CoreAssetSubscriptions { get; set; }

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

            modelBuilder.Entity<RoleDO>().ToTable("RefRole",schema:"system");
            modelBuilder.Entity<GenderDO>().ToTable("RefGender", schema: "master");
            modelBuilder.Entity<DataTypeDO>().ToTable("RefDataType",schema:"system");
            modelBuilder.Entity<EnumTypeDO>().ToTable("RefEnumType",schema: "system");
            modelBuilder.Entity<IndustryDO>().ToTable("RefIndustry",schema: "system");
            modelBuilder.Entity<EnumValueDO>().ToTable("RefEnumValue",schema: "system");
            modelBuilder.Entity<AddressDO>().ToTable("CoreAddress", schema: "org");
            modelBuilder.Entity<CategoryDO>().ToTable("RefCategory", schema: "system");
            modelBuilder.Entity<CoreAssetDO>().ToTable("CoreAsset", schema: "org");
            modelBuilder.Entity<CoreAssetTemplateDO>().ToTable("CoreAssetTemplate",schema:"org");
            modelBuilder.Entity<CoreAssetCustomTemplateDO>().ToTable("CoreAssetCustomTemplate", schema: "org");
            modelBuilder.Entity<CoreAssetCancellationPolicyDO>().ToTable("CoreAssetCancellationPolicy",schema:"org");
            modelBuilder.Entity<CoreAssetBookingDO>().ToTable("CoreAssetBooking", schema: "org");
            modelBuilder.Entity<CoreAssetBookingCancellationDO>().ToTable("CoreAssetBookingCancellation", schema: "org");
            modelBuilder.Entity<CoreAssetBookingSlotDO>().ToTable("CoreAssetBookingSlot",schema:"org");
            modelBuilder.Entity<CoreAssetSubscriptionDO>().ToTable("CoreAssetSubscription", schema: "org");
            modelBuilder.Entity<OrganizationDO>().ToTable("RefOrganization", schema: "master");
            modelBuilder.Entity<OrganizationRoleDO>().ToTable("RefOrganizationRole", schema: "dbo");
            modelBuilder.Entity<UserDO>().ToTable("RefUser", schema: "master");
            modelBuilder.Entity<SubscriptionDO>().ToTable("RefSubscription", schema: "master");
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
