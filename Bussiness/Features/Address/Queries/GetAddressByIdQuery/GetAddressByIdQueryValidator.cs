using FluentValidation;

namespace Bussiness.Features.Address.Queries.GetAddressByIdQuery
{
    public class GetAddressByIdQueryValidator
        : AbstractValidator<GetAddressByIdQuery>
    {
        #region Ctor

        public GetAddressByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
