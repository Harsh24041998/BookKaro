using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class CoreAssetCancellationPolicyConfiguration
        : IEntityTypeConfiguration<CoreAssetCancellationPolicyDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CoreAssetCancellationPolicyDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefCoreAssetCancellationPolicy");

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
                .Property(e => e.PriorUptillPeriod)
                .HasColumnType("INT")
                .HasColumnOrder(3);
            builder
                .Property(e => e.ReturnRate)
                .HasColumnType("INT")
                .HasColumnOrder(4);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(5);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(6);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(7);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(8);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefCoreAssetCancellationPolicy_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.CoreAsset)
                .WithMany(e => e.CoreAssetCancellationPolicys)
                .HasForeignKey(e => e.AssetId)
                .HasConstraintName("FK_RefCoreAsset_RefCoreAssetCancellationPolicy_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }

        #endregion
    }
}
