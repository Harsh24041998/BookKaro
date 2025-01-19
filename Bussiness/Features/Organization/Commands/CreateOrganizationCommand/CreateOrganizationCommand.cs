using MediatR;

namespace Bussiness.Features.Organization.Commands.CreateOrganizationCommand
{
    public class CreateOrganizationCommand : IRequest<CreateOrganizationCommandDTO>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public Guid IndustryId { get; set; } = default;
        public bool IsMobile { get; set; } = default;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
