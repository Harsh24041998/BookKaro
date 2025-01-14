
using MediatR;

namespace Bussiness.Features.Role.Queries.GetRoleByIdQuery
{
    public class GetRoleByIdQuery
        : IRequest<GetRoleByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
