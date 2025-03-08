using MediatR;

namespace Bussiness.Features.Transaction.Queries.GetTransactionByIdQuery
{
    public class GetTransactionByIdQuery
        : IRequest<GetTransactionByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
