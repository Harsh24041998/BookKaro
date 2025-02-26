using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class CoreAssetDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid OrganizationID { get; set; }
        public Guid CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AssetNo { get; set; } = default;
        public int Priority { get; set; } = default;
        public int SlotInterval { get; set; } = default;
        public bool IsOnline { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion

        #region Navigation Properties

        public CategoryDO Category { get; set; } = default!;
        public ICollection<CoreAssetTemplateDO>? CoreAssetTemplates { get; }
        public ICollection<CoreAssetBookingDO>? CoreAssetBookings { get; }
        public ICollection<CoreAssetCustomTemplateDO>? CoreAssetCustomTemplates { get; }
        public ICollection<CoreAssetCancellationPolicyDO>? CoreAssetCancellationPolicys { get; }
        public ICollection<CoreAssetSubscriptionDO>? CoreAssetSubscriptions { get; }
        public OrganizationDO Organization { get; set; } = default!;

        #endregion

        #endregion
    }
}
