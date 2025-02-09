using MediatR;

namespace Bussiness.Features.CoreAssetBooking.Commands.CreateCoreAssetBookingCommand
{
    public class CreateCoreAssetBookingCommand : IRequest<CreateCoreAssetBookingCommandDTO>
    {
        #region Properties
        public Guid AssetId { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public int Amount { get; set; } = default;
        public int Advance { get; set; } = default;
        public int Balance { get; set; } = default;
        public int Status { get; set; } = default;

        #endregion
    }
}
