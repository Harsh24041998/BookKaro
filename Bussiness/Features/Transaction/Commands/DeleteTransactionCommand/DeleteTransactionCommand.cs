using MediatR;

namespace Bussiness.Features.Transaction.Commands.DeleteTransactionCommand
{
    public class DeleteTransactionCommand : IRequest<DeleteTransactionCommandDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
