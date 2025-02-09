using MediatR;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.UpdateCoreAssetBookingSlotCommand
{
    public class UpdateCoreAssetBookingSlotCommand : IRequest<UpdateCoreAssetBookingSlotCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid AssetBookingId { get; set; } = default;
        public DateTime SlotDate { get; set; } = default;
        public TimeSpan StartTime { get; set; } = default;
        public TimeSpan EndTime { get; set; } = default;
        public int Rate { get; set; } = default;
        public int Status { get; set; } = default;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
