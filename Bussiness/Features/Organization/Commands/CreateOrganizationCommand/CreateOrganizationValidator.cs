using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.Organization.Commands.CreateOrganizationCommand
{
    public class CreateOrganizationValidator
        : AbstractValidator<CreateOrganizationCommand>
    {
        #region Fields

        private readonly IOrganizationRepository _OrganizationRepository;

        #endregion

        #region Ctor

        public CreateOrganizationValidator(IOrganizationRepository OrganizationRepository)
        {
            _OrganizationRepository = OrganizationRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Must(ValidateIfModuleDoesNotExist).WithMessage("Group already exists");

            RuleFor(x => x.IndustryId)
                .NotEmpty().WithMessage("IndustryId cannot be empty.")
                .NotNull().WithMessage("IndustryId is required.");
        }

        #endregion

        #region Methods

        private bool ValidateIfModuleDoesNotExist(string? activityName)
        {
            var results = _OrganizationRepository.ReadAllAsNoTracking().Where(e => e.Name == activityName).FirstOrDefault();

            return results == null ? true : false;
        }

        #endregion
    }
}
