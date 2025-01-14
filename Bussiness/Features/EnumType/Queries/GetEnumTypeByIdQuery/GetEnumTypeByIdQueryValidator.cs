using FluentValidation;

namespace Bussiness.Features.EnumType.Queries.GetEnumTypeByIdQuery
{
    public class GetEnumTypeByIdQueryValidator
        : AbstractValidator<GetEnumTypeByIdQuery>
    {
        #region Ctor

        public GetEnumTypeByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
