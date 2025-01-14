namespace Bussiness.DomainObjects.Common
{
    public abstract class AuditableDO
        : BaseDO
    {
        #region Properties

        #region Column Properties

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = default;
        public string? UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedOn { get; set; } = default;

        #endregion

        #endregion
    }
}
