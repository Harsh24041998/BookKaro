using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public class CoreAssetTemplateDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid AssetId { get; set; } = default;
        public Guid DayEnumValueId { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;

        #endregion

        #region Navigation Properties

        public EnumValueDO EnumValue { get; set; } = default!;
        public CoreAssetDO CoreAsset { get; set; } = default!;

        #endregion

        #endregion
    }
}
