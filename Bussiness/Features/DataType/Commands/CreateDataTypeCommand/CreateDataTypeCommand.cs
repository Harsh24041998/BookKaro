using MediatR;

namespace Bussiness.Features.DataType.Commands.CreateDataTypeCommand
{
    public class CreateDataTypeCommand : IRequest<CreateDataTypeCommandDTO>
    {
        #region Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = default;

        #endregion
    }
}
