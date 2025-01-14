using FluentValidation;

namespace Bussiness.Features.Gender.Commands.DeleteGenderCommand
{
    public class DeleteGenderValidator : AbstractValidator<DeleteGenderCommand>
    {
        #region Ctor

        public DeleteGenderValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
