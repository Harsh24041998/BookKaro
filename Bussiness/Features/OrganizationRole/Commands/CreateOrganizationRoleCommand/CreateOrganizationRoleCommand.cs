using MediatR;

namespace Bussiness.Features.OrganizationRole.Commands.CreateOrganizationRoleCommand
{
    public class CreateOrganizationRoleCommand : IRequest<CreateOrganizationRoleCommandDTO>
    {
        #region Properties
        public Guid UserId { get; set; } = default;
        public Guid OrganizationId { get; set; } = default;
        public Guid RoleId { get; set; } = default;



        #endregion
    }
}
