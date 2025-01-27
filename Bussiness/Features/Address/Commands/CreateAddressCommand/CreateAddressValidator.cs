using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.Address.Commands.CreateAddressCommand
{
    public class CreateAddressValidator
        : AbstractValidator<CreateAddressCommand>
    {
        #region Fields

        private readonly IAddressRepository _AddressRepository;

        #endregion

        #region Ctor

        public CreateAddressValidator(IAddressRepository AddressRepository)
        {
            _AddressRepository = AddressRepository;

            //Rule Writing
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

        #endregion

        #region Methods

        private bool ValidateIfModuleDoesNotExist(string? activityName)
        {
            var results = _AddressRepository.ReadAllAsNoTracking().Where(e => e.Address == activityName).FirstOrDefault();

            return results == null ? true : false;
        }

        #endregion
    }
}
