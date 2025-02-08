using MediatR;

namespace Bussiness.Features.OrganizationRole.Commands.UpdateOrganizationRoleCommand
{
    public class UpdateOrganizationRoleCommand : IRequest<UpdateOrganizationRoleCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; } = default;
        public Guid UserId { get; set; } = default;
        public Guid RoleId { get; set; } = default;


        #endregion
    }
}
