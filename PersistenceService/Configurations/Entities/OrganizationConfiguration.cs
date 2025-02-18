using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class OrganizationConfiguration
        : IEntityTypeConfiguration<OrganizationDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<OrganizationDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefOrganization");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(1);
            builder
                .Property(e => e.IndustryId)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(3);
            builder
              .Property(e => e.IsMobile)
              .HasColumnType("BIT")
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
                .HasName("PK_RefOrganization_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.Industry)
                .WithMany(e => e.Organizations)
                .HasForeignKey(e => e.IndustryId)
                .HasConstraintName("FK_RefIndustries_RefOrganization_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(e => e.CoreAssets)
                .WithOne(e => e.Organization);

            builder
                .HasOne(e => e.Address)
                .WithOne(e => e.Organization);

            builder
                .HasMany(e => e.OrganizationRoles)
                .WithOne(e => e.Organization);
        }

        #endregion
    }
}
