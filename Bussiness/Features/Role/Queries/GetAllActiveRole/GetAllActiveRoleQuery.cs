using MediatR;

namespace Bussiness.Features.Role.Queries.GetAllActiveRole
{
    public class GetAllActiveRoleQuery
         : IRequest<IEnumerable<GetAllActiveRoleDTO>>
    {
    }
}
