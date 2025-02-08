using MediatR;

namespace Bussiness.Features.OrganizationRole.Queries.GetOrganizationRoleByIdQuery
{
    public class GetOrganizationRoleByIdQuery
        : IRequest<GetOrganizationRoleByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
