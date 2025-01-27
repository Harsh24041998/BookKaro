using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class OrganizationRoleDO
         : AuditableDO
    {
        #region Properties

        #region Column Properties

        public Guid UserId { get; set; } = default;
        public Guid OrganizationId { get; set; } = default;
        public Guid RoleId { get; set; } = default;

        #endregion

        #region Navigation Properties
        public UserDO User { get; set; } = default!;
        public RoleDO Role { get; set; } = default!;
        public OrganizationDO Organization { get; set; } = default!;


        #endregion

        #endregion

    }
}
