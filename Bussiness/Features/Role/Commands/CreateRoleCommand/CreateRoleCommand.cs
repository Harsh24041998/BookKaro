
using MediatR;

namespace Bussiness.Features.Role.Commands.CreateRoleCommand
{
    public class CreateRoleCommand : IRequest<CreateRoleCommandDTO>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
