using FluentValidation;

namespace Bussiness.Features.DataType.Queries.GetAllDataTypeByNameQuery
{
    public class GetAllDataTypeByNameQueryValidator
        : AbstractValidator<GetAllDataTypeByNameQuery>
    {
        #region Ctor

        public GetAllDataTypeByNameQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }

        #endregion
    }
}
