using FluentValidation;

namespace Bussiness.Features.Organization.Commands.DeleteOrganizationCommand
{
    public class DeleteOrganizationValidator : AbstractValidator<DeleteOrganizationCommand>
    {
        #region Ctor

        public DeleteOrganizationValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
