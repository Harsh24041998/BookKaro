using MediatR;

namespace Bussiness.Features.EnumValue.Commands.DeleteEnumValueCommand
{
    public class DeleteEnumValueCommand : IRequest<DeleteEnumValueCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
