using FluentValidation;

namespace Bussiness.Features.Subscription.Queries.GetSubscriptionByIdQuery
{
    public class GetSubscriptionByIdQueryValidator : AbstractValidator<GetSubscriptionByIdQuery>
    {
        public GetSubscriptionByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
