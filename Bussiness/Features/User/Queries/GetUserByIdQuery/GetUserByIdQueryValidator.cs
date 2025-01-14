using FluentValidation;

namespace Bussiness.Features.User.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryValidator
        : AbstractValidator<GetUserByIdQuery>
    {
        #region Ctor

        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
