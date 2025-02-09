using FluentValidation;

namespace Bussiness.Features.CoreAssetBooking.Commands.DeleteCoreAssetBookingCommand
{
    public class DeleteCoreAssetBookingValidator : AbstractValidator<DeleteCoreAssetBookingCommand>
    {
        #region Ctor

        public DeleteCoreAssetBookingValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
