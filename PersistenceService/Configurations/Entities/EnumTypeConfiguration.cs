using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersistenceService.Configurations.Entities
{
    public sealed class EnumTypeConfiguration
        : IEntityTypeConfiguration<EnumTypeDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<EnumTypeDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefEnumType");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(1);
            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Code)
                .HasColumnType("VARCHAR(50)")
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
            builder
              .Property(e => e.IsActive)
              .HasColumnType("BIT")
              .HasColumnOrder(9);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefEnumType_Id");

            //Configure index(s)
            builder
               .HasOne(e => e.EnumValue)
               .WithOne(e => e.EnumType);
        }

        #endregion
    }
}
