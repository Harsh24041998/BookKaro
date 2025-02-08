using FluentValidation;

namespace Bussiness.Features.OrganizationRole.Queries.GetOrganizationRoleByIdQuery
{
    public class GetOrganizationRoleByIdQueryValidator
        : AbstractValidator<GetOrganizationRoleByIdQuery>
    {
        #region Ctor

        public GetOrganizationRoleByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
