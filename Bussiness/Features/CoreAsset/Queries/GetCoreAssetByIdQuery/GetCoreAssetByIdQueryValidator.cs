using FluentValidation;

namespace Bussiness.Features.CoreAsset.Queries.GetCoreAssetByIdQuery
{
    public class GetCoreAssetByIdQueryValidator
        : AbstractValidator<GetCoreAssetByIdQuery>
    {
        #region Ctor

        public GetCoreAssetByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
