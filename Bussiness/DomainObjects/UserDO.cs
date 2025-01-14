using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public sealed class UserDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid GenderId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public int OTPAttempts { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion

        #region Navigation Properties

        public GenderDO Gender { get; set; } = default!;

        #endregion

        #endregion
    }
}
