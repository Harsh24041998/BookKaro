using FluentValidation;

namespace Bussiness.Features.User.Queries.GetUserByMobileNumberQuery
{
    public class GetUserByMobileNumberQueryValidator
        : AbstractValidator<GetUserByMobileNumberQuery>
    {
        #region Ctor

        public GetUserByMobileNumberQueryValidator()
        {
            RuleFor(x => x.MobileNumber).NotEmpty().NotNull();
        }

        #endregion
    }
}
