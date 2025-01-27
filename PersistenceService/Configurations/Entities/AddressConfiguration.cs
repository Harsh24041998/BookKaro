using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace PersistenceService.Configurations.Entities
{
    public class AddressConfiguration
        : IEntityTypeConfiguration<AddressDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<AddressDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefAddress");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(1);
            builder
                .Property(e => e.OrganizationId)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Address)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Town)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.City)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(5);
            builder
                .Property(e => e.State)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(6);
            builder
                .Property(e => e.Pincode)
                .HasColumnType("VARCHAR(10)")
                .HasColumnOrder(7);
            builder
                .Property(e => e.Country)
                .HasColumnType("VARCHAR(50)")
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

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefAddress_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations


            builder
                    .HasOne(e => e.Organization)            // Organization has one Address
                    .WithOne(e => e.Address)                // Address has one Organization
                    .HasForeignKey<AddressDO>(e => e.OrganizationId)  // Specify the foreign key property in the Address class
                    .HasConstraintName("FK_RefOrganization_RefAddress_OrganizationId")
                    .OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}
