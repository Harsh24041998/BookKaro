using FluentValidation;

namespace Bussiness.Features.CoreAssetTemplate.Commands.DeleteCoreAssetTemplateCommand
{
    public class DeleteCoreAssetTemplateValidator : AbstractValidator<DeleteCoreAssetTemplateCommand>
    {
        #region Ctor

        public DeleteCoreAssetTemplateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
