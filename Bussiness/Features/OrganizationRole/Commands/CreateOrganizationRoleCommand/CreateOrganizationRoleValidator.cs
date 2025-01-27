using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.OrganizationRole.Commands.CreateOrganizationRoleCommand
{
    public class CreateOrganizationRoleValidator
        : AbstractValidator<CreateOrganizationRoleCommand>
    {
        #region Fields

        private readonly IOrganizationRoleRepository _OrganizationRoleRepository;

        #endregion

        #region Ctor

        public CreateOrganizationRoleValidator(IOrganizationRoleRepository OrganizationRoleRepository)
        {
            _OrganizationRoleRepository = OrganizationRoleRepository;

            //Rule Writing

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.")
                .NotNull().WithMessage("UserId is required.");

            RuleFor(x => x.OrganizationId)
                .NotEmpty().WithMessage("OrganizationId cannot be empty.")
                .NotNull().WithMessage("OrganizationId is required.");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("RoleId cannot be empty.")
                .NotNull().WithMessage("RoleId is required.");
        }

        public Guid id { get; private set; }

        #endregion

        #region Methods

        private bool ValidateIfModuleDoesNotExist(string? activityName)
        {
            var results = _OrganizationRoleRepository.ReadAllAsNoTracking().Where(e => e.Id == id).FirstOrDefault();

            return results == null ? true : false;
        }

        #endregion
    }
}
