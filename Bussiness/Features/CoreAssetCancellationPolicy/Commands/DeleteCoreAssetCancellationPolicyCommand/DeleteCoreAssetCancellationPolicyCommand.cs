using MediatR;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Commands.DeleteCoreAssetCancellationPolicyCommand
{
    public class DeleteCoreAssetCancellationPolicyCommand : IRequest<DeleteCoreAssetCancellationPolicyCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
