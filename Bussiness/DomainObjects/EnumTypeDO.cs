using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class EnumTypeDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion

        #region Navigation Properties

        public EnumValueDO EnumValue { get; set; } = default!;

        #endregion

        #endregion
    }
}
