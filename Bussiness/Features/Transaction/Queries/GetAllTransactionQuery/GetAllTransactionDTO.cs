namespace Bussiness.Features.Transaction.Queries.GetAllTransactionQuery
{
    public class GetAllTransactionDTO
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; } = default;
        public string Particular { get; set; } = string.Empty;
        public int Amount { get; set; } = default;
        public bool IsCredited { get; set; } = default;
        public Guid TransactionStatusEnumValueId { get; set; } = default;
        public string OrganizationName { get; set; } = string.Empty;
        public string EnumValueName { get; set; } = string.Empty;


        #endregion
    }
}
