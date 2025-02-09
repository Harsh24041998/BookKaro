using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class CoreAssetBookingSlotDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid AssetBookingId { get; set; } = default;
        public DateTime SlotDate { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;
        public int Status { get; set; } = default;

        #endregion

        #region Navigation Properties

        public CoreAssetBookingDO CoreAssetBooking { get; set; } = default!;

        #endregion

        #endregion
    }
}
