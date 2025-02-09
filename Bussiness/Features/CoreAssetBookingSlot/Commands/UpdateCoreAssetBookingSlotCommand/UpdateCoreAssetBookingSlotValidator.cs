using Bussiness.Contracts.Repositories;
using Bussiness.Features.CoreAssetBooking.Commands.UpdateCoreAssetBookingCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Features.CoreAssetBookingSlot.Commands.UpdateCoreAssetBookingSlotCommand
{
    public class UpdateCoreAssetBookingSlotValidator
        : AbstractValidator<UpdateCoreAssetBookingSlotCommand>
    {
        #region Fields

        private readonly ICoreAssetBookingSlotRepository _CoreAssetBookingSlotRepository;

        #endregion

        #region Ctor

        public UpdateCoreAssetBookingSlotValidator(ICoreAssetBookingSlotRepository CoreAssetBookingSlotRepository)
        {
            _CoreAssetBookingSlotRepository = CoreAssetBookingSlotRepository;

            //Rule Writing
            RuleFor(x => x.AssetBookingId)
                .NotEmpty().WithMessage("AssetBookingId cannot be empty.")
                .NotNull().WithMessage("AssetBookingId is required.");

            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("Rate cannot be empty.")
                .NotNull().WithMessage("Rate is required.");

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

        }

        #endregion

        #region Methods



        #endregion
    }
}
