using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class UserConfiguration
        : IEntityTypeConfiguration<UserDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<UserDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefUser");

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
                .Property(e => e.GenderId)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.MobileNumber)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.EmailId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(5);
            builder
                .Property(e => e.OTPAttempts)
                .HasColumnType("INTEGER")
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
            builder
              .Property(e => e.IsActive)
              .HasColumnType("BIT")
              .HasColumnOrder(11);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefUser_Id");

            //Configure index(s)

            //Configure relations

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.Gender)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.GenderId)
                .HasConstraintName("FK_RefGender_RefUser_Id")
                .OnDelete(DeleteBehavior.NoAction);


        }

        #endregion
    }
}
