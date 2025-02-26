using MediatR;

namespace Bussiness.Features.CoreAssetSubscription.Commands.UpdateCoreAssetSubscriptionCommand
{
    public class UpdateCoreAssetSubscriptionCommand : IRequest<UpdateCoreAssetSubscriptionCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public int AmountPaid { get; set; } = default;
        public int DaysLeftForExpiry { get; set; } = default;
        public bool IsExpired { get; set; } = default;
        public bool IsActive { get; set; } = default;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
