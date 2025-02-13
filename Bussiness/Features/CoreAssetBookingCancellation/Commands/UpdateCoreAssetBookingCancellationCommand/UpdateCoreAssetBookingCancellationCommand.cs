using MediatR;

namespace Bussiness.Features.CoreAssetBookingCancellation.Commands.UpdateCoreAssetBookingCancellationCommand
{
    public class UpdateCoreAssetBookingCancellationCommand : IRequest<UpdateCoreAssetBookingCancellationCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid AssetBookingId { get; set; } = default;
        public int Amount { get; set; } = default;
        public int Refund { get; set; } = default;
        public string BankAccountName { get; set; } = string.Empty;
        public string BankAccountNo { get; set; } = string.Empty;
        public string BankIfscCode { get; set; } = string.Empty;
        public int Status { get; set; } = default;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
