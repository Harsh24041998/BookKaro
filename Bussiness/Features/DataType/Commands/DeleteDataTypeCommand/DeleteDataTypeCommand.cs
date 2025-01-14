using MediatR;

namespace Bussiness.Features.DataType.Commands.DeleteDataTypeCommand
{
    public class DeleteDataTypeCommand : IRequest<DeleteDataTypeCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
