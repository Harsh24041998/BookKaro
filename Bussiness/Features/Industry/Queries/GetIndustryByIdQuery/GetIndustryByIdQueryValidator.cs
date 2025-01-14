using FluentValidation;

namespace Bussiness.Features.Industry.Queries.GetIndustryByIdQuery
{
    public class GetIndustryByIdQueryValidator
        : AbstractValidator<GetIndustryByIdQuery>
    {
        #region Ctor

        public GetIndustryByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
