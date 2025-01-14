using MediatR;

namespace Bussiness.Features.Gender.Commands.DeleteGenderCommand
{
    public class DeleteGenderCommand : IRequest<DeleteGenderCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
