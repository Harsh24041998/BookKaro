using MediatR;

namespace Bussiness.Features.CoreAssetBooking.Commands.UpdateCoreAssetBookingCommand
{
    public class UpdateCoreAssetBookingCommand : IRequest<UpdateCoreAssetBookingCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid AssetId { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public int Amount { get; set; } = default;
        public int Advance { get; set; } = default;
        public int Balance { get; set; } = default;
        public int Status { get; set; } = default;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
