using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class GenderConfiguration
        : IEntityTypeConfiguration<GenderDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<GenderDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefGender");

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
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(5);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(6);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(7);
            builder
              .Property(e => e.IsActive)
              .HasColumnType("BIT")
              .HasColumnOrder(8);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefGender_Id");

            //Configure index(s)

            //Configure relations
            builder
                .HasMany(e => e.Users)
                .WithOne(e => e.Gender);

            //Configure foreign key(s) and relations


        }

        #endregion
    }
}
