using FluentValidation;

namespace Bussiness.Features.Gender.Queries.GetGenderByIdQuery
{
    public class GetGenderByIdQueryValidator
        : AbstractValidator<GetGenderByIdQuery>
    {
        #region Ctor

        public GetGenderByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
