namespace Bussiness.Features.CoreAssetSubscription.Queries.GetAllCoreAssetSubscriptionQuery
{
    public class GetAllCoreAssetSubscriptionQueryDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public int AmountPaid { get; set; } = default;
        public int DaysLeftForExpiry { get; set; } = default;
        public bool IsExpired { get; set; } = default;
        public bool IsActive { get; set; } = default;
        public string AssetName { get; set; } = string.Empty;

        #endregion
    }
}
