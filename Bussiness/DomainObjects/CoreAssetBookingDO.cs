using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class CoreAssetBookingDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid AssetId { get; set; } = default;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PhoneNo { get; set; }= string.Empty;
        public int Amount { get; set; } = default;
        public int Advance { get; set; } = default;
        public int Balance { get; set; } = default;
        public int Status { get; set; } = default;

        #endregion

        #region Navigation Properties

        public CoreAssetDO CoreAsset { get; set; } = default!;
        public ICollection<CoreAssetBookingSlotDO>? CoreAssetBookingSlots { get; }

        #endregion

        #endregion
    }
}
