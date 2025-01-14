using FluentValidation;

namespace Bussiness.Features.EnumType.Queries.GetAllEnumTypeByNameQuery
{
    public class GetAllEnumTypeByNameQueryValidator
        : AbstractValidator<GetAllEnumTypeByNameQuery>
    {
        #region Ctor

        public GetAllEnumTypeByNameQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }

        #endregion
    }
}
