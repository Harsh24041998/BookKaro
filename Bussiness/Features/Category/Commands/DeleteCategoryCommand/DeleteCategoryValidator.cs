using FluentValidation;

namespace Bussiness.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        #region Ctor

        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
