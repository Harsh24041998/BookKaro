using MediatR;

namespace Bussiness.Features.Transaction.Commands.UpdateTransactionCommand
{
    public class UpdateTransactionCommand : IRequest<UpdateTransactionCommandDTO>
    {
        #region properties

        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; } = default;
        public string Particular { get; set; } = string.Empty;
        public int Amount { get; set; } = default;
        public bool IsCredited { get; set; } = default;
        public Guid TransactionStatusEnumValueId { get; set; } = default;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = default;

        #endregion
    }
}
