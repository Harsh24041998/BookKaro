using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class CoreAssetCustomTemplateDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid AssetId { get; set; } = default;
        public DateTime Date { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;

        #endregion

        #region Navigation Properties

        public CoreAssetDO CoreAsset { get; set; } = default!;

        #endregion

        #endregion
    }
}
