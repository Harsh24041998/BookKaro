using FluentValidation;

namespace Bussiness.Features.OrganizationRole.Commands.UpdateOrganizationRoleCommand
{
    public class UpdateOrganizationRoleValidator : AbstractValidator<UpdateOrganizationRoleCommand>
    {
        #region Ctor

        public UpdateOrganizationRoleValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .NotNull().WithMessage("Id is required.");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("RoleId cannot be empty.")
                .NotNull().WithMessage("RoleId is required.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.")
                .NotNull().WithMessage("UserId is required.");

            RuleFor(x => x.OrganizationId)
                .NotEmpty().WithMessage("OrganizationId cannot be empty.")
                .NotNull().WithMessage("OrganizationId is required.");
        }

        #endregion
    }
}
