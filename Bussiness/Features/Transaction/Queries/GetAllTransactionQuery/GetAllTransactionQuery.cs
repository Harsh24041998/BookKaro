using MediatR;

namespace Bussiness.Features.Transaction.Queries.GetAllTransactionQuery
{
    public class GetAllTransactionQuery
         : IRequest<IEnumerable<GetAllTransactionDTO>>
    {
    }
}
