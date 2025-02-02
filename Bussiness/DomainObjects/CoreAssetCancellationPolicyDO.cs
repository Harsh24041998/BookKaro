using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class CoreAssetCancellationPolicyDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid AssetId { get; set; } = default;
        public int PriorUptillPeriod { get; set; } = default;
        public int ReturnRate { get; set; } = default;

        #endregion

        #region Navigation Properties

        public CoreAssetDO CoreAsset { get; set; } = default!;

        #endregion

        #endregion
    }
}
