using FluentValidation;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.DeleteCoreAssetBookingSlotCommand
{
    public class DeleteCoreAssetBookingSlotValidator : AbstractValidator<DeleteCoreAssetBookingSlotCommand>
    {
        #region Ctor

        public DeleteCoreAssetBookingSlotValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
