using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class CoreAssetBookingConfiguration
        : IEntityTypeConfiguration<CoreAssetBookingDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CoreAssetBookingDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefCoreAssetBooking");

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
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.PhoneNo)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.Amount)
                .HasColumnType("INT")
                .HasColumnOrder(5);
            builder
                .Property(e => e.Balance)
                .HasColumnType("INT")
                .HasColumnOrder(6);
            builder
                .Property(e => e.Advance)
                .HasColumnType("INT")
                .HasColumnOrder(7);
            builder
                .Property(e => e.Status)
                .HasColumnType("INT")
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
                .HasName("PK_RefCoreAssetBooking_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasMany(e => e.CoreAssetBookingSlots)
                .WithOne(e => e.CoreAssetBooking);

            builder
                .HasOne(e => e.CoreAsset)
                .WithMany(e => e.CoreAssetBookings)
                .HasForeignKey(e => e.AssetId)
                .HasConstraintName("FK_RefCoreAsset_RefCoreAssetBooking_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }

        #endregion
    }
}
