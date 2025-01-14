using MediatR;

namespace Bussiness.Features.EnumType.Commands.CreateEnumTypeCommand
{
    public class CreateEnumTypeCommand : IRequest<CreateEnumTypeCommandDTO>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
