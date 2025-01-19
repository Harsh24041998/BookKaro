using FluentValidation;

namespace Bussiness.Features.Organization.Commands.UpdateOrganizationCommand
{
    public class UpdateOrganizationValidator : AbstractValidator<UpdateOrganizationCommand>
    {
        #region Ctor

        public UpdateOrganizationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.IndustryId)
                .NotEmpty().WithMessage("IndustryId cannot be empty.")
                .NotNull().WithMessage("IndustryId is required.");
        }

        #endregion
    }
}
