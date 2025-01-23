using MediatR;

namespace Bussiness.Features.Subscription.Queries.GetSubscriptionByIdQuery
{
    public class GetSubscriptionByIdQuery : IRequest<GetSubscriptionByIdDTO>
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion
    }
}
