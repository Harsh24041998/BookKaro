using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public sealed class EnumValueConfiguration
        : IEntityTypeConfiguration<EnumValueDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<EnumValueDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefEnumValue");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(1);
            builder
                .Property(e => e.EnumTypeId)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.Code)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(5);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(6);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(7);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(8);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(9);
            builder
              .Property(e => e.IsActive)
              .HasColumnType("BIT")
              .HasColumnOrder(10);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefEnumValue_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
            .HasOne(u => u.EnumType)                
            .WithOne(g => g.EnumValue)                 
            .HasForeignKey<EnumValueDO>(u => u.EnumTypeId) 
            .HasConstraintName("FK_RefGender_RefUser_Id")  
            .OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}
