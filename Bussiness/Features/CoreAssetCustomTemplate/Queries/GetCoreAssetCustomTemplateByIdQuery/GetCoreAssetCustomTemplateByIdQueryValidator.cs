using FluentValidation;

namespace Bussiness.Features.CoreAssetCustomTemplate.Queries.GetCoreAssetCustomTemplateByIdQuery
{
    public class GetCoreAssetCustomTemplateByIdQueryValidator
        : AbstractValidator<GetCoreAssetCustomTemplateByIdQuery>
    {
        #region Ctor

        public GetCoreAssetCustomTemplateByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
