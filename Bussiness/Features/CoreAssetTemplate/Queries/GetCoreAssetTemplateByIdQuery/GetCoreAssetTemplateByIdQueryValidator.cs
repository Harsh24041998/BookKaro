using FluentValidation;

namespace Bussiness.Features.CoreAssetTemplate.Queries.GetCoreAssetTemplateByIdQuery
{
    public class GetCoreAssetTemplateByIdQueryValidator
        : AbstractValidator<GetCoreAssetTemplateByIdQuery>
    {
        #region Ctor

        public GetCoreAssetTemplateByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
