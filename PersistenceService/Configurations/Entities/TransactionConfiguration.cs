using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class TransactionConfiguration
        : IEntityTypeConfiguration<TransactionDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<TransactionDO> builder)
        {
            // Configure table name
            builder
                .ToTable("CoreTransaction");

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
                .Property(e => e.Particular)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Amount)
                .HasColumnType("INT")
                .HasColumnOrder(4);
            builder
                .Property(e => e.IsCredited)
                .HasColumnType("BIT")
                .HasColumnOrder(5);
            builder
                .Property(e => e.TransactionStatusEnumValueId)
                .HasColumnType("CHAR(16)")
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
                .HasName("PK_CoreTransaction_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations


            builder
                 .HasOne(e => e.Organization)
                 .WithMany(e => e.Transactions)
                 .HasForeignKey(e => e.OrganizationId)
                 .HasConstraintName("FK_RefOrganization_CoreTransaction_Id")
                 .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.EnumValue)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.TransactionStatusEnumValueId)
                .HasConstraintName("FK_RefEnumValue_CoreTransaction_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}
