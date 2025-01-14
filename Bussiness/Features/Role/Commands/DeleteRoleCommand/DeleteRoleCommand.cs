using MediatR;

namespace Bussiness.Features.Role.Commands.DeleteRoleCommand
{
    public class DeleteRoleCommand : IRequest<DeleteRoleCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
