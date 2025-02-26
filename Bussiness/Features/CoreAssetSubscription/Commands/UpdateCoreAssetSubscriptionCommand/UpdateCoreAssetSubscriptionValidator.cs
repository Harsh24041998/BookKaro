using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.CoreAssetSubscription.Commands.UpdateCoreAssetSubscriptionCommand
{
    public class UpdateCoreAssetSubscriptionValidator
        : AbstractValidator<UpdateCoreAssetSubscriptionCommand>
    {
        #region Fields

        private readonly ICoreAssetSubscriptionRepository _CoreAssetSubscriptionRepository;

        #endregion

        #region Ctor

        public UpdateCoreAssetSubscriptionValidator(ICoreAssetSubscriptionRepository CoreAssetSubscriptionRepository)
        {
            _CoreAssetSubscriptionRepository = CoreAssetSubscriptionRepository;

            //Rule Writing
            RuleFor(x => x.AssetId)
                .NotEmpty().WithMessage("AssetId cannot be empty.")
                .NotNull().WithMessage("AssetId is required.");

            RuleFor(x => x.AmountPaid)
                .NotEmpty().WithMessage("Amount Paid cannot be empty.")
                .NotNull().WithMessage("Amount Paid is required.");

            RuleFor(x => x.DaysLeftForExpiry)
                .NotEmpty().WithMessage("Days Left For Expiry cannot be empty.")
                .NotNull().WithMessage("Days Left For Expiry is required.");

            RuleFor(x => x.IsExpired)
                .NotEmpty().WithMessage("IsExpired cannot be empty.")
                .NotNull().WithMessage("IsExpired is required.");

            RuleFor(x => x.IsActive)
                .NotEmpty().WithMessage("IsActive cannot be empty.")
                .NotNull().WithMessage("IsActive is required.");

        }

        #endregion

        #region Methods



        #endregion
    }
}
