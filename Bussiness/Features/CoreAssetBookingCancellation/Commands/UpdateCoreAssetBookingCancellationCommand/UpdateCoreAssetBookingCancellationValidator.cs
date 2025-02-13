using FluentValidation;

namespace Bussiness.Features.CoreAssetBookingCancellation.Commands.UpdateCoreAssetBookingCancellationCommand
{
    public class UpdateCoreAssetBookingCancellationValidator
        : AbstractValidator<UpdateCoreAssetBookingCancellationCommand>
    {
        #region Fields



        #endregion

        #region Ctor

        public UpdateCoreAssetBookingCancellationValidator()
        {

            //Rule Writing
            RuleFor(x => x.AssetBookingId)
                .NotEmpty().WithMessage("AssetBookingId cannot be empty.")
                .NotNull().WithMessage("AssetBookingId is required.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount cannot be empty.")
                .NotNull().WithMessage("Amount is required.");

            RuleFor(x => x.Refund)
                .NotEmpty().WithMessage("Refund cannot be empty.")
                .NotNull().WithMessage("Refund is required.");

            RuleFor(x => x.BankAccountName)
                .NotEmpty().WithMessage("BankAccountName cannot be empty.")
                .NotNull().WithMessage("BankAccountName is required.");

            RuleFor(x => x.BankAccountNo)
                .NotEmpty().WithMessage("BankAccountNo cannot be empty.")
                .NotNull().WithMessage("BankAccountNo is required.");

            RuleFor(x => x.BankIfscCode)
                .NotEmpty().WithMessage("BankIfscCode cannot be empty.")
                .NotNull().WithMessage("BankIfscCode is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status cannot be empty.")
                .NotNull().WithMessage("Status is required.");

        }

        #endregion

        #region Methods



        #endregion
    }
}
