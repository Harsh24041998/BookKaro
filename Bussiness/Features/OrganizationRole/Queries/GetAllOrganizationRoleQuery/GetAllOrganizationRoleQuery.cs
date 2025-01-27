using MediatR;

namespace Bussiness.Features.OrganizationRole.Queries.GetAllOrganizationRoleQuery
{
    public class GetAllOrganizationRoleQuery
         : IRequest<IEnumerable<GetAllOrganizationRoleDTO>>
    {
    }
}
