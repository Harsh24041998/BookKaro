using MediatR;

namespace Bussiness.Features.CoreAssetBookingCancellation.Commands.CreateCoreAssetBookingCancellationCommand
{
    public class CreateCoreAssetBookingCancellationCommand : IRequest<CreateCoreAssetBookingCancellationCommandDTO>
    {
        #region Properties
        public Guid AssetBookingId { get; set; } = default;
        public int Amount { get; set; } = default;
        public int Refund { get; set; } = default;
        public string BankAccountName { get; set; } = string.Empty;
        public string BankAccountNo { get; set; } = string.Empty;
        public string BankIfscCode { get; set; } = string.Empty;
        public int Status { get; set; } = default;

        #endregion
    }
}
