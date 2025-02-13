using MediatR;

namespace Bussiness.Features.CoreAssetBookingCancellation.Commands.DeleteCoreAssetBookingCancellationCommand
{
    public class DeleteCoreAssetBookingCancellationCommand : IRequest<DeleteCoreAssetBookingCancellationCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
