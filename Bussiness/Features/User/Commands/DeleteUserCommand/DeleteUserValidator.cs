
using FluentValidation;

namespace Bussiness.Features.User.Commands.DeleteUserCommand
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        #region Ctor

        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
