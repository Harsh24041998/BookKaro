using Bussiness.DomainObjects.Common;

namespace Bussiness.DomainObjects
{
    public class CategoryDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties
        public Guid IndustryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion

        #region Navigation Properties

        public IndustryDO Industry { get; set; } = default!;
        public ICollection<CoreAssetDO>? CoreAssets { get; }

        #endregion

        #endregion
    }
}
