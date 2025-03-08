using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class TransactionDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid OrganizationId { get; set; } = default;
        public string Particular { get; set; } = string.Empty;
        public int Amount { get; set; } = default;
        public bool IsCredited { get; set; } = default;
        public Guid TransactionStatusEnumValueId { get; set; } = default;


        #endregion

        #region Navigation Properties

        public OrganizationDO Organization { get; set; } = default!;
        public EnumValueDO EnumValue { get; set; } = default!;

        #endregion

        #endregion
    }
}
