using FluentValidation;

namespace Bussiness.Features.CoreAssetBookingCancellation.Commands.DeleteCoreAssetBookingCancellationCommand
{
    public class DeleteCoreAssetBookingCancellationValidator : AbstractValidator<DeleteCoreAssetBookingCancellationCommand>
    {
        #region Ctor

        public DeleteCoreAssetBookingCancellationValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
