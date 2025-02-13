using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class CoreAssetBookingCancellationDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid AssetBookingId { get; set; } = default;
        public int Amount { get; set; } = default;
        public int Refund { get; set; } = default;
        public string BankAccountName { get; set; } = string.Empty;
        public string BankAccountNo { get; set; } = string.Empty;
        public string BankIfscCode { get; set; } = string.Empty;
        public int Status { get; set; } = default;

        #endregion

        #region Navigation Properties

        public CoreAssetBookingDO CoreAssetBooking { get; set; } = default!;

        #endregion

        #endregion
    }
}
