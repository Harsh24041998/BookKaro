using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class CoreAssetConfiguration
        : IEntityTypeConfiguration<CoreAssetDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CoreAssetDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefCoreAsset");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(1);
            builder
                .Property(e => e.OrganizationID)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.CategoryID)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.AssetNo)
                .HasColumnType("INT")
                .HasColumnOrder(5);
            builder
                .Property(e => e.Priority)
                .HasColumnType("INT")
                .HasColumnOrder(6);
            builder
                .Property(e => e.SlotInterval)
                .HasColumnType("INT")
                .HasColumnOrder(7);
            builder
              .Property(e => e.IsOnline)
              .HasColumnType("BIT")
              .HasColumnOrder(8);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(9);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(10);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(11);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(12);
            builder
              .Property(e => e.IsActive)
              .HasColumnType("BIT")
              .HasColumnOrder(13);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefCoreAsset_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.Organization)
                .WithMany(e => e.CoreAssets)
                .HasForeignKey(e => e.OrganizationID)
                .HasConstraintName("FK_RefOrganization_RefCoreAsset_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Category)
                .WithMany(e => e.CoreAssets)
                .HasForeignKey(e => e.CategoryID)
                .HasConstraintName("FK_RefCategory_RefCoreAsset_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}
