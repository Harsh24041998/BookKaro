using MediatR;

namespace Bussiness.Features.EnumValue.Commands.CreateEnumValueCommand
{
    public class CreateEnumValueCommand : IRequest<CreateEnumValueCommandDTO>
    {
        #region Properties
        public Guid EnumTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
