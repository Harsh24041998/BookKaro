using MediatR;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Commands.CreateCoreAssetCancellationPolicyCommand
{
    public class CreateCoreAssetCancellationPolicyCommand : IRequest<CreateCoreAssetCancellationPolicyCommandDTO>
    {
        #region Properties
        public Guid AssetId { get; set; } = default;
        public int PriorUptillPeriod { get; set; } = default;
        public int ReturnRate { get; set; } = default;

        #endregion
    }
}
