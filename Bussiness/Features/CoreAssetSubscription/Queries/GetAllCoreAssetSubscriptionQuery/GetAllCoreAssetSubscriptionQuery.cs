using MediatR;

namespace Bussiness.Features.CoreAssetSubscription.Queries.GetAllCoreAssetSubscriptionQuery
{
    public class GetAllCoreAssetSubscriptionQuery
         : IRequest<IEnumerable<GetAllCoreAssetSubscriptionQueryDTO>>
    { 
    }
}
