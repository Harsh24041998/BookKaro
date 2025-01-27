using Bussiness.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PersistenceService.Configurations.Entities
{
    public class OrganizationRoleConfiguration
        : IEntityTypeConfiguration<OrganizationRoleDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<OrganizationRoleDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefOrganizationRole");

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
                .Property(e => e.UserId)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.RoleId)
                .HasColumnType("CHAR(16)")
                .HasColumnOrder(2);


            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefOrganizationRole_Id");

            //Configure index(s)

            //Configure foreign key(s) and relations

            builder
                .HasOne(e => e.Organization)
                .WithMany(e => e.OrganizationRoles)
                .HasForeignKey(e => e.OrganizationId)
                .HasConstraintName("FK_RefOrganization_RefOrganizationRole_Id")
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.OrganizationRoles)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_RefUser_RefOrganizationRole_Id")
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(e => e.Role)
                .WithMany(e => e.OrganizationRoles)
                .HasForeignKey(e => e.RoleId)
                .HasConstraintName("FK_RefRole_RefOrganizationRole_Id")
                .OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}
