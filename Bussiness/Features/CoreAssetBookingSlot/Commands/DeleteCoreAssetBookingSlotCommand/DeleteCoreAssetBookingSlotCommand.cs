using MediatR;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.DeleteCoreAssetBookingSlotCommand
{
    public class DeleteCoreAssetBookingSlotCommand : IRequest<DeleteCoreAssetBookingSlotCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
