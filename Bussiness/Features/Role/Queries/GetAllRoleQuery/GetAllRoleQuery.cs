using MediatR;

namespace Bussiness.Features.Role.Queries.GetAllRoleQuery
{
    public class GetAllRoleQuery
         : IRequest<IEnumerable<GetAllRoleDTO>>
    {
    }
}
