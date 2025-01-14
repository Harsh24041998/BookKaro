using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceService.Configurations.Entities
{
    public class CategoryConfiguration
        : IEntityTypeConfiguration<CategoryDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CategoryDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefCategory");

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
                .HasName("PK_RefCategory_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.Industry)
                .WithMany(e => e.Categories)
                .HasForeignKey(e => e.IndustryId)
                .HasConstraintName("FK_RefIndustries_RefCategory_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}
