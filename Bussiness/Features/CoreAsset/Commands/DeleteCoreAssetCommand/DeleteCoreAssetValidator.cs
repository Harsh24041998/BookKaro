using FluentValidation;

namespace Bussiness.Features.CoreAsset.Commands.DeleteCoreAssetCommand
{
    public class DeleteCoreAssetValidator : AbstractValidator<DeleteCoreAssetCommand>
    {
        #region Ctor

        public DeleteCoreAssetValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
