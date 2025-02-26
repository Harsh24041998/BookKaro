

using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public sealed class CoreAssetSubscriptionConfiguration
        : IEntityTypeConfiguration<CoreAssetSubscriptionDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CoreAssetSubscriptionDO> builder)
        {
            // Configure table name
            builder
                .ToTable("CoreAssetSubscription");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(1);
            builder
                .Property(e => e.AssetId)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.AmountPaid)
                .HasColumnType("INT")
                .HasColumnOrder(3);
            builder
                .Property(e => e.DaysLeftForExpiry)
                .HasColumnType("INT")
                .HasColumnOrder(4);
            builder
                .Property(e => e.IsExpired)
                .HasColumnType("BIT")
                .HasColumnOrder(5);
            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasColumnOrder(6);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(7);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(8);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(9);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(10);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_CoreAssetSubscription_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.CoreAsset)
                .WithMany(e => e.CoreAssetSubscriptions)
                .HasForeignKey(e => e.AssetId)
                .HasConstraintName("FK_RefCoreAsset_RefCoreAssetSubscription_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }

        #endregion
    }
}
