using MediatR;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.CreateCoreAssetBookingSlotCommand
{
    public class CreateCoreAssetBookingSlotCommand : IRequest<CreateCoreAssetBookingSlotCommandDTO>
    {
        #region Properties
        public Guid AssetBookingId { get; set; } = default;
        public DateTime SlotDate { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;
        public int Status { get; set; } = default;

        #endregion
    }
}
