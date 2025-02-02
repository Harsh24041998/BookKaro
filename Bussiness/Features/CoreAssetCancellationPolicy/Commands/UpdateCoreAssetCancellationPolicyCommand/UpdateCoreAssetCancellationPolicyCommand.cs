using MediatR;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Commands.UpdateCoreAssetCancellationPolicyCommand
{
    public class UpdateCoreAssetCancellationPolicyCommand : IRequest<UpdateCoreAssetCancellationPolicyCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public int PriorUptillPeriod { get; set; } = default;
        public int ReturnRate { get; set; } = default;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
