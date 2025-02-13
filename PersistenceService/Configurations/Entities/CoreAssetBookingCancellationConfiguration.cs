using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class CoreAssetBookingCancellationConfiguration
        : IEntityTypeConfiguration<CoreAssetBookingCancellationDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CoreAssetBookingCancellationDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefCoreAssetBookingCancellation");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(1);
            builder
                .Property(e => e.AssetBookingId)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Amount)
                .HasColumnType("INT")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Refund)
                .HasColumnType("INT")
                .HasColumnOrder(4);
            builder
                .Property(e => e.BankAccountName)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(5);
            builder
                .Property(e => e.BankAccountNo)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(6);
            builder
                .Property(e => e.BankIfscCode)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(6);
            builder
                .Property(e => e.Status)
                .HasColumnType("INT")
                .HasColumnOrder(7);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(8);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(9);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(10);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(11);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefCoreAssetBookingCancellation_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.CoreAssetBooking)
                .WithMany(e => e.CoreAssetBookingCancellations)
                .HasForeignKey(e => e.AssetBookingId)
                .HasConstraintName("FK_RefCoreAsset_RefCoreAssetBookingCancellation_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }

        #endregion
    }
}
