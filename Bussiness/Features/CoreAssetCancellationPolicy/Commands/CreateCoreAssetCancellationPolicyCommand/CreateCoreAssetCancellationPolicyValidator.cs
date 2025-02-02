using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Commands.CreateCoreAssetCancellationPolicyCommand
{
    public class CreateCoreAssetCancellationPolicyValidator
        : AbstractValidator<CreateCoreAssetCancellationPolicyCommand>
    {
        #region Fields

        private readonly ICoreAssetCancellationPolicyRepository _CoreAssetCancellationPolicyRepository;

        #endregion

        #region Ctor

        public CreateCoreAssetCancellationPolicyValidator(ICoreAssetCancellationPolicyRepository CoreAssetCancellationPolicyRepository)
        {
            _CoreAssetCancellationPolicyRepository = CoreAssetCancellationPolicyRepository;

            //Rule Writing
            RuleFor(x => x.AssetId)
                .NotEmpty().WithMessage("AssetId cannot be empty.")
                .NotNull().WithMessage("AssetId is required.");

            RuleFor(x => x.ReturnRate)
                .NotEmpty().WithMessage("ReturnRate cannot be empty.")
                .NotNull().WithMessage("ReturnRate is required.");

            RuleFor(x => x.PriorUptillPeriod)
                .NotEmpty().WithMessage("PriorUptillPeriod cannot be empty.")
                .NotNull().WithMessage("PriorUptillPeriod is required.");

        }

        #endregion

        #region Methods



        #endregion
    }
}
