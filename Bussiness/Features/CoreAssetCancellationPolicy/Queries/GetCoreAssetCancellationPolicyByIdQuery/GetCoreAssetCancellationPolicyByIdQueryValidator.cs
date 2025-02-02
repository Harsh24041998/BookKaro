using FluentValidation;

namespace Bussiness.Features.CoreAssetCancellationPolicy.Queries.GetCoreAssetCancellationPolicyByIdQuery
{
    public class GetCoreAssetCancellationPolicyByIdQueryValidator
        : AbstractValidator<GetCoreAssetCancellationPolicyByIdQuery>
    {
        #region Ctor

        public GetCoreAssetCancellationPolicyByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
