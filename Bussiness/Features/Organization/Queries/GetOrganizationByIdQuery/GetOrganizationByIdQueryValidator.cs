using FluentValidation;

namespace Bussiness.Features.Organization.Queries.GetOrganizationByIdQuery
{
    public class GetOrganizationByIdQueryValidator
        : AbstractValidator<GetOrganizationByIdQuery>
    {
        #region Ctor

        public GetOrganizationByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }

        #endregion
    }
}
