using FluentValidation;

namespace Bussiness.Features.Category.Queries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQueryValidator
        : AbstractValidator<GetCategoryByIdQuery>
    {
        #region Ctor

        public GetCategoryByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
