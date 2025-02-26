using FluentValidation;

namespace Bussiness.Features.CoreAssetSubscription.Queries.GetCoreAssetSubscriptionByIdQuery
{
    public class GetCoreAssetSubscriptionByIdQueryValidator
        : AbstractValidator<GetCoreAssetSubscriptionByIdQuery>
    {
        #region Ctor

        public GetCoreAssetSubscriptionByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
