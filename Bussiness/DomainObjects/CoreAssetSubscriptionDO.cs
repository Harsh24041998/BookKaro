using Bussiness.DomainObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.DomainObjects
{
    public sealed class CoreAssetSubscriptionDO
        : AuditableDO
    {
        #region Properties

        #region Column Properties

        public Guid AssetId { get; set; } = default;
        public int AmountPaid { get; set; } = default;
        public int DaysLeftForExpiry { get; set; } = default;
        public bool IsExpired { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion

        #region Navigation Properties

        public CoreAssetDO CoreAsset { get; set; } = default!;

        #endregion

        #endregion
    }
}
