using MediatR;

namespace Bussiness.Features.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressCommand : IRequest<DeleteAddressCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
