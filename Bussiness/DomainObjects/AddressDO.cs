using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class AddressDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid OrganizationId { get; set; } = default;
        public string Address { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;


        #endregion

        #region Navigation Properties

        public OrganizationDO Organization { get; set; } = default!;

        #endregion

        #endregion
    }
}
