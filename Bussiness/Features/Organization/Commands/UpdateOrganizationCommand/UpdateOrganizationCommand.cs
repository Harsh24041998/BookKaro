using MediatR;

namespace Bussiness.Features.Organization.Commands.UpdateOrganizationCommand
{
    public class UpdateOrganizationCommand : IRequest<UpdateOrganizationCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid IndustryId { get; set; } = default;
        public bool IsMobile { get; set; } = default;
        public bool IsActive { get; set; } = false;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
