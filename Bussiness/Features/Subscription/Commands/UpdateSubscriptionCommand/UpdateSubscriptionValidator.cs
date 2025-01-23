using FluentValidation;

namespace Bussiness.Features.Subscription.Commands.UpdateSubscriptionCommand
{
    public class UpdateSubscriptionValidator : AbstractValidator<UpdateSubscriptionCommand>
    {
        public UpdateSubscriptionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description is required.")
                .MinimumLength(2).WithMessage("Description must be at least 2 characters.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.DiscountRate)
                .GreaterThanOrEqualTo(0).WithMessage("Discount rate must be non-negative.")
                .LessThanOrEqualTo(100).WithMessage("Discount rate cannot exceed 100.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive status is required.");
        }
    }
}
