using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class CoreAssetBookingSlotConfiguration
        : IEntityTypeConfiguration<CoreAssetBookingSlotDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CoreAssetBookingSlotDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefCoreAssetBookingSlot");

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
                .Property(e => e.SlotDate)
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
                .HasName("PK_RefCoreAssetBookingSlot_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.CoreAssetBooking)
                .WithMany(e => e.CoreAssetBookingSlots)
                .HasForeignKey(e => e.AssetBookingId)
                .HasConstraintName("FK_RefCoreAsset_RefCoreAssetBookingSlot_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }

        #endregion
    }
}
