using MediatR;

namespace Bussiness.Features.OrganizationRole.Commands.DeleteOrganizationRoleCommand
{
    public class DeleteOrganizationRoleCommand : IRequest<DeleteOrganizationRoleCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
