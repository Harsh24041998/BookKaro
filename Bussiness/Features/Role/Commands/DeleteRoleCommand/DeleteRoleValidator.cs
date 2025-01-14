using FluentValidation;

namespace Bussiness.Features.Role.Commands.DeleteRoleCommand
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Ctor

        public DeleteRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
