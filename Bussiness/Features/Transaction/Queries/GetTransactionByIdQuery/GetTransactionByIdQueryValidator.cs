using FluentValidation;

namespace Bussiness.Features.Transaction.Queries.GetTransactionByIdQuery
{
    public class GetTransactionByIdQueryValidator
        : AbstractValidator<GetTransactionByIdQuery>
    {
        #region Ctor

        public GetTransactionByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
