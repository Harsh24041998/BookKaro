using MediatR;

namespace Bussiness.Features.Transaction.Commands.CreateTransactionCommand
{
    public class CreateTransactionCommand : IRequest<CreateTransactionCommandDTO>
    {
        #region Properties
        public Guid OrganizationId { get; set; } = default;
        public string Particular { get; set; } = string.Empty;
        public int Amount { get; set; } = default;
        public bool IsCredited { get; set; } = default;
        public Guid TransactionStatusEnumValueId { get; set; } = default;

        #endregion
    }
}
