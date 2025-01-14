using FluentValidation;

namespace Bussiness.Features.Industry.Queries.GetAllIndustryByNameQuery
{
    public class GetAllIndustryByNameQueryValidator
        : AbstractValidator<GetAllIndustryByNameQuery>
    {
        #region Ctor

        public GetAllIndustryByNameQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }

        #endregion
    }
}
