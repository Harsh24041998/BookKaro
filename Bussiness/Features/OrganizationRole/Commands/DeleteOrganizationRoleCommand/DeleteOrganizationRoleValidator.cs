using FluentValidation;

namespace Bussiness.Features.OrganizationRole.Commands.DeleteOrganizationRoleCommand
{
    public class DeleteOrganizationRoleValidator : AbstractValidator<DeleteOrganizationRoleCommand>
    {
        #region Ctor

        public DeleteOrganizationRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
