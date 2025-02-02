namespace Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetAllCoreAssetCancellationPolicyQuery
{
    public class GetAllCoreAssetCancellationPolicyDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public int PriorUptillPeriod { get; set; } = default;
        public int ReturnRate { get; set; } = default;
        public string AssetName { get; set; } = string.Empty;

        #endregion
    }
}
