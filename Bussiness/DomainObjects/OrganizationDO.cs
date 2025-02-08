using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class OrganizationDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties

        public string Name { get; set; } = string.Empty;
        public Guid IndustryId { get; set; } = default;
        public bool IsMobile { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion

        #region Navigation Properties
        public IndustryDO Industry { get; set; } = default!;
        public ICollection<OrganizationRoleDO>? OrganizationRoles { get; }
        public ICollection<CoreAssetDO>? CoreAssets { get; }
        public AddressDO Address { get; set; } = default!;
        #endregion

        #endregion
    }
}
