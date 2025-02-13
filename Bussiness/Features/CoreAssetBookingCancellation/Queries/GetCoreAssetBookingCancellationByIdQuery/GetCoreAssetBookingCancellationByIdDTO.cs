namespace Bussiness.Features.CoreAssetBookingCancellation.Queries.GetCoreAssetBookingCancellationByIdQuery
{
    public class GetCoreAssetBookingCancellationByIdDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid AssetBookingId { get; set; } = default;
        public int Amount { get; set; } = default;
        public int Refund { get; set; } = default;
        public string BankAccountName { get; set; } = string.Empty;
        public string BankAccountNo { get; set; } = string.Empty;
        public string BankIfscCode { get; set; } = string.Empty;
        public int Status { get; set; } = default;
        public string AssetBookingName { get; set; } = string.Empty;

        #endregion
    }
}
