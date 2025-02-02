using FluentValidation;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Commands.DeleteCoreAssetCancellationPolicyCommand
{
    public class DeleteCoreAssetCancellationPolicyValidator : AbstractValidator<DeleteCoreAssetCancellationPolicyCommand>
    {
        #region Ctor

        public DeleteCoreAssetCancellationPolicyValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
