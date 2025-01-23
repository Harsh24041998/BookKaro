using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class SubscriptionDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } = default;
        public int DiscountRate { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion

        #region Navigation Properties

        #endregion

        #endregion
    }
}
