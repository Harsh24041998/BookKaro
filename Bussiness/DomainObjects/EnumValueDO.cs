using Bussiness.DomainObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.DomainObjects
{
    public class EnumValueDO
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

        #endregion

        #endregion
    }
}
