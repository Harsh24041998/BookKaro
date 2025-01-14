
using MediatR;

namespace Bussiness.Features.User.Commands.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest<DeleteUserCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
