using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class EnumValueDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid EnumTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion

        #region Navigation Properties

        public EnumTypeDO EnumType { get; set; } = default!;
        public ICollection<CoreAssetTemplateDO>? CoreAssetTemplates { get; }
        public ICollection<TransactionDO>? Transactions { get; }

        #endregion

        #endregion
    }
}
