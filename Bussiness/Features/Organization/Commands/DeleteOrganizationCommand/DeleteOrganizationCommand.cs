using MediatR;

namespace Bussiness.Features.Organization.Commands.DeleteOrganizationCommand
{
    public class DeleteOrganizationCommand : IRequest<DeleteOrganizationCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
