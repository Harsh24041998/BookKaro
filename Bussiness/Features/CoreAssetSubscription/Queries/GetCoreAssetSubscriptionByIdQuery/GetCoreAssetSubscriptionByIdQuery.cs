using MediatR;

namespace Bussiness.Features.CoreAssetSubscription.Queries.GetCoreAssetSubscriptionByIdQuery
{
    public class GetCoreAssetSubscriptionByIdQuery
         : IRequest<GetCoreAssetSubscriptionByIdDTO>
    {
        #region properties

        public Guid? Id { get; set; }

        #endregion
    }
}
