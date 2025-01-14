using FluentValidation;

namespace Bussiness.Features.EnumValue.Queries.GetEnumValueByIdQuery
{
    public class GetEnumValueByIdQueryValidator
        : AbstractValidator<GetEnumValueByIdQuery>
    {
        #region Ctor

        public GetEnumValueByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
