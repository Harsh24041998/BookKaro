using FluentValidation;

namespace Bussiness.Features.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressCommand>
    {
        #region Ctor

        public UpdateAddressValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Must(ValidateIfModuleDoesNotExist).WithMessage("Group already exists");

            RuleFor(x => x.OrganizationId)
                .NotEmpty().WithMessage("Organizationd cannot be empty.")
                .NotNull().WithMessage("OrganizationId is required.");
        }

        private bool ValidateIfModuleDoesNotExist(string arg)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
