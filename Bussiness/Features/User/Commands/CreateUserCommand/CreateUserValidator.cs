using Bussiness.Contracts.Repositories;
using FluentValidation;

namespace Bussiness.Features.User.Commands.CreateUserCommand
{
    public class CreateUserValidator
        : AbstractValidator<CreateUserCommand>
    {
        #region Fields

        private readonly IUserRepository _UserRepository;

        #endregion

        #region Ctor

        public CreateUserValidator(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

            //Rule Writing
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.EmailId)
                .NotEmpty().WithMessage("EmailId cannot be empty.")
                .NotNull().WithMessage("EmailId is required.")
                .MinimumLength(2).WithMessage("EmailId must be at least 2 characters.");

            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("MobileNumber cannot be empty.")
                .NotNull().WithMessage("MobileNumber is required.")
                .MinimumLength(2).WithMessage("MobileNumber must be at least 2 characters.")
                .MaximumLength(100).WithMessage("MobileNumber cannot exceed 100 characters.");

        }

        #endregion

        #region Methods

        private bool ValidateIfUserDoesNotExist(string? activityName)
        {
            var results = _UserRepository.ReadAllAsNoTracking().Where(e => e.MobileNumber == activityName).FirstOrDefault();

            return results == null ? true : false;
        }

        #endregion
    }
}
