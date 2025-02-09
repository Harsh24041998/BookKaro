namespace Bussiness.Features.CoreAssetBooking.Queries.GetCoreAssetBookingByIdQuery
{
    public class GetCoreAssetBookingByIdDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public int Amount { get; set; } = default;
        public int Advance { get; set; } = default;
        public int Balance { get; set; } = default;
        public int Status { get; set; } = default;
        public string AssetName { get; set; } = string.Empty;

        #endregion
    }
}
