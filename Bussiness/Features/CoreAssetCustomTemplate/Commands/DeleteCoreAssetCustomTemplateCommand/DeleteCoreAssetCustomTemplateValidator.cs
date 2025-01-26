using FluentValidation;

namespace Bussiness.Features.CoreAssetCustomTemplate.Commands.DeleteCoreAssetCustomTemplateCommand
{
    public class DeleteCoreAssetCustomTemplateValidator : AbstractValidator<DeleteCoreAssetCustomTemplateCommand>
    {
        #region Ctor

        public DeleteCoreAssetCustomTemplateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
