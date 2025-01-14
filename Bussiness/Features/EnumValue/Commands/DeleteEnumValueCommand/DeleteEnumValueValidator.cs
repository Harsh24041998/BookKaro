using FluentValidation;

namespace Bussiness.Features.EnumValue.Commands.DeleteEnumValueCommand
{
    public class DeleteEnumValueValidator : AbstractValidator<DeleteEnumValueCommand>
    {
        #region Ctor

        public DeleteEnumValueValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
