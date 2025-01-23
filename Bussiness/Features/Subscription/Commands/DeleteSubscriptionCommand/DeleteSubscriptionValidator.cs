using FluentValidation;

namespace Bussiness.Features.Subscription.Commands.DeleteSubscriptionCommand
{
    public class DeleteSubscriptionValidator : AbstractValidator<DeleteSubscriptionCommand>
    {
        #region Ctor

        public DeleteSubscriptionValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
