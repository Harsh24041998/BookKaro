using Bussiness.Features.DataType.Commands.DeleteDataTypeCommand;
using MediatR;

namespace Bussiness.Features.EnumType.Commands.DeleteEnumTypeCommand
{
    public class DeleteEnumTypeCommand : IRequest<DeleteEnumTypeCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
