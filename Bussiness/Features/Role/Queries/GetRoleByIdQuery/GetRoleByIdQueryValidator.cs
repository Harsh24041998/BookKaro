using FluentValidation;

namespace Bussiness.Features.Role.Queries.GetRoleByIdQuery
{
    public class GetRoleByIdQueryValidator
        : AbstractValidator<GetRoleByIdQuery>
    {
        #region Ctor

        public GetRoleByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
