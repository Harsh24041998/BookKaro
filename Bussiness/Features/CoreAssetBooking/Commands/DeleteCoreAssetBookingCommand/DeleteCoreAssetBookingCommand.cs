using MediatR;

namespace Bussiness.Features.CoreAssetBooking.Commands.DeleteCoreAssetBookingCommand
{
    public class DeleteCoreAssetBookingCommand : IRequest<DeleteCoreAssetBookingCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
