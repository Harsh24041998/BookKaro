using MediatR;

namespace Bussiness.Features.CoreAssetSubscription.Commands.DeleteCoreAssetSubscriptionCommand
{
    public class DeleteCoreAssetSubscriptionCommand : IRequest<DeleteCoreAssetSubscriptionCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
