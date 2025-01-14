using FluentValidation;

namespace Bussiness.Features.EnumType.Commands.DeleteEnumTypeCommand
{
    public class DeleteEnumTypeValidator : AbstractValidator<DeleteEnumTypeCommand>
    {
        #region Ctor

        public DeleteEnumTypeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
