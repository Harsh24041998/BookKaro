using MediatR;

namespace Bussiness.Features.CoreAssetSubscription.Commands.CreateCoreAssetSubscriptionCommand
{
    public class CreateCoreAssetSubscriptionCommand : IRequest<CreateCoreAssetSubscriptionCommandDTO>
    {
        #region Properties
        public Guid AssetId { get; set; } = default;
        public int AmountPaid { get; set; } = default;
        public int DaysLeftForExpiry { get; set; } = default;
        public bool IsExpired { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
