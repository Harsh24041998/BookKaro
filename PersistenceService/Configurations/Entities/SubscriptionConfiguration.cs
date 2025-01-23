using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class SubscriptionConfiguration
        : IEntityTypeConfiguration<SubscriptionDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<SubscriptionDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefSubscription");

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
                .Property(e => e.Price)
                .HasColumnType("INT")
                .HasColumnOrder(4);
            builder
                .Property(e => e.DiscountRate)
                .HasColumnType("INT")
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
                .HasName("PK_RefSubscription_Id");

            //Configure index(s)

            //Configure relations

            //Configure foreign key(s) and relations


        }

        #endregion
    }
}
