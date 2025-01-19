using MediatR;

namespace Bussiness.Features.Organization.Queries.GetAllOrganizationQuery
{
    public class GetAllOrganizationQuery
         : IRequest<IEnumerable<GetAllOrganizationDTO>>
    {
    }
}
