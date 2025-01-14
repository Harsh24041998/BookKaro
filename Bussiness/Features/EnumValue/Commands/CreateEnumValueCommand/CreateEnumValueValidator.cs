using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.EnumValue.Commands.CreateEnumValueCommand
{
    public class CreateEnumValueValidator
        : AbstractValidator<CreateEnumValueCommand>
    {
        #region Fields

        private readonly IEnumValueRepository _enumValueRepository;

        #endregion

        #region Ctor

        public CreateEnumValueValidator(IEnumValueRepository EnumValueRepository)
        {
            _enumValueRepository = EnumValueRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Must(ValidateIfModuleDoesNotExist).WithMessage("Group already exists");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description is required.")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");
        }

        #endregion

        #region Methods

        private bool ValidateIfModuleDoesNotExist(string? activityName)
        {
            var results = _enumValueRepository.ReadAllAsNoTracking().Where(e => e.Name == activityName).FirstOrDefault();

            return results == null ? true : false;
        }

        #endregion
    }
}
