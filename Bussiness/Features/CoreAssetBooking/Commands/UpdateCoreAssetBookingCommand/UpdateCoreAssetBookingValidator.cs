using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.CoreAssetBooking.Commands.UpdateCoreAssetBookingCommand
{
    public class UpdateCoreAssetBookingValidator
        : AbstractValidator<UpdateCoreAssetBookingCommand>
    {
        #region Fields

        private readonly ICoreAssetBookingRepository _CoreAssetBookingRepository;

        #endregion

        #region Ctor

        public UpdateCoreAssetBookingValidator(ICoreAssetBookingRepository CoreAssetBookingRepository)
        {
            _CoreAssetBookingRepository = CoreAssetBookingRepository;

            //Rule Writing
            RuleFor(x => x.AssetId)
                .NotEmpty().WithMessage("AssetId cannot be empty.")
                .NotNull().WithMessage("AssetId is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.");

            RuleFor(x => x.PhoneNo)
                .NotEmpty().WithMessage("PhoneNo cannot be empty.")
                .NotNull().WithMessage("PhoneNo is required.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount cannot be empty.")
                .NotNull().WithMessage("Amount is required.");

            RuleFor(x => x.Balance)
                .NotEmpty().WithMessage("Balance cannot be empty.")
                .NotNull().WithMessage("Balance is required.");

            RuleFor(x => x.Advance)
                .NotEmpty().WithMessage("Advance cannot be empty.")
                .NotNull().WithMessage("Advance is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status cannot be empty.")
                .NotNull().WithMessage("Status is required.");

        }

        #endregion

        #region Methods



        #endregion
    }
}
