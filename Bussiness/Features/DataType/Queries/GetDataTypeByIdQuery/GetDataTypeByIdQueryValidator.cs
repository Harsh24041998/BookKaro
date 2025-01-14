using FluentValidation;

namespace Bussiness.Features.DataType.Queries.GetDataTypeByIdQuery
{
    public class GetDataTypeByIdQueryValidator
        : AbstractValidator<GetDataTypeByIdQuery>
    {
        #region Ctor

        public GetDataTypeByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
