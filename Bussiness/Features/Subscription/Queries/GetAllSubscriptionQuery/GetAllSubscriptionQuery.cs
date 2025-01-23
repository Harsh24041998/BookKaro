using MediatR;

namespace Bussiness.Features.Subscription.Queries.GetAllSubscriptionQuery
{
    public class GetAllSubscriptionQuery : IRequest<IEnumerable<GetAllSubscriptionDTO>>
    {
    }
}
