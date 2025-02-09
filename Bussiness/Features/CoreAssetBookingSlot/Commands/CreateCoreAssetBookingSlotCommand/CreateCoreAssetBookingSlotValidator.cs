using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.CreateCoreAssetBookingSlotCommand
{
    public class CreateCoreAssetBookingSlotValidator
        : AbstractValidator<CreateCoreAssetBookingSlotCommand>
    {
        #region Fields

        private readonly ICoreAssetBookingRepository _CoreAssetBookingRepository;

        #endregion

        #region Ctor

        public CreateCoreAssetBookingSlotValidator(ICoreAssetBookingRepository CoreAssetBookingRepository)
        {
            _CoreAssetBookingRepository = CoreAssetBookingRepository;

            //Rule Writing
            RuleFor(x => x.AssetBookingId)
                .NotEmpty().WithMessage("AssetBookingId cannot be empty.")
                .NotNull().WithMessage("AssetBookingId is required.");

            RuleFor(x => x.SlotDate)
                .NotEmpty().WithMessage("SlotDate cannot be empty.")
                .NotNull().WithMessage("SlotDate is required.");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("StartTime cannot be empty.")
                .NotNull().WithMessage("StartTime is required.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("EndTime cannot be empty.")
                .NotNull().WithMessage("EndTime is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status cannot be empty.")
                .NotNull().WithMessage("Status is required.");

            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("Rate cannot be empty.")
                .NotNull().WithMessage("Rate is required.");


        }

        #endregion

        #region Methods



        #endregion
    }
}
