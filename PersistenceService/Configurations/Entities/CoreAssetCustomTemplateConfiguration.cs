using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class CoreAssetCustomTemplateConfiguration
        : IEntityTypeConfiguration<CoreAssetCustomTemplateDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CoreAssetCustomTemplateDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefCoreAssetCustomTemplate");

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
                .Property(e => e.Date)
                .HasColumnType("DATETIME")
                .HasColumnOrder(3);
            builder
                .Property(e => e.StartTime)
                .HasColumnType("TIME")
                .HasColumnOrder(4);
            builder
                .Property(e => e.EndTime)
                .HasColumnType("TIME")
                .HasColumnOrder(5);
            builder
                .Property(e => e.Rate)
                .HasColumnType("INT")
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
                .HasName("PK_RefCoreAssetCustomTemplate_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.CoreAsset)
                .WithMany(e => e.CoreAssetCustomTemplates)
                .HasForeignKey(e => e.AssetId)
                .HasConstraintName("FK_RefCoreAsset_RefCoreAssetCustomTemplate_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }

        #endregion
    }
}
