using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.Gender.Commands.CreateGenderCommand
{
    public class CreateGenderValidator
        : AbstractValidator<CreateGenderCommand>
    {
        #region Fields

        private readonly IGenderRepository _GenderRepository;

        #endregion

        #region Ctor

        public CreateGenderValidator(IGenderRepository GenderRepository)
        {
            _GenderRepository = GenderRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.")
                .Must(ValidateIfGenderDoesNotExist).WithMessage("Gender already exists");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description is required.")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");
        }

        #endregion

        #region Methods

        private bool ValidateIfGenderDoesNotExist(string? activityName)
        {
            var results = _GenderRepository.ReadAllAsNoTracking().Where(e => e.Name == activityName).FirstOrDefault();

            return results == null ? true : false;
        }

        #endregion
    }
}
