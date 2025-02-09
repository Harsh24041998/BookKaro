namespace Bussiness.Features.CoreAssetBookingSlot.Queries.GetCoreAssetBookingSlotByIdQuery
{
    public class GetCoreAssetBookingSlotByIdDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid AssetBookingId { get; set; } = default;
        public DateTime SlotDate { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;
        public int Status { get; set; } = default;
        public string AssetBookingName { get; set; } = string.Empty;

        #endregion
    }
}
