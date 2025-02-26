using FluentValidation;

namespace Bussiness.Features.CoreAssetSubscription.Commands.DeleteCoreAssetSubscriptionCommand
{
    public class DeleteCoreAssetSubscriptionValidator : AbstractValidator<DeleteCoreAssetSubscriptionCommand>
    {
        #region Ctor

        public DeleteCoreAssetSubscriptionValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
